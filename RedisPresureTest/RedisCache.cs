using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GoBear.Infrastructures
{
    public class RedisCache 
    {
        //private static string Host="104.45.24.164:6379";
        private static string Host = "192.168.1.9:2819";
        private static readonly int DatabaseNo;
        private static Lazy<ConnectionMultiplexer> lazyRedisConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(Host);
        });

        private static object locker = new object();
        private static ConnectionMultiplexer redisConnection;


        static RedisCache()
        {
            DatabaseNo = 0;
        }

        public RedisCache()
        {
           
        }

        public static ConnectionMultiplexer RedisConnection
        {
            get
            {
                if (redisConnection == null)
                {
                    return redisConnection = lazyRedisConnection.Value;
                }

                if (redisConnection.IsConnected == false)
                {
                    lock (locker)
                    {
                        if (redisConnection.IsConnected == false)
                        {
                            redisConnection.Close(allowCommandsToComplete: false);
                            redisConnection.Dispose();
                            redisConnection = null;

                            redisConnection = ConnectionMultiplexer.Connect(Host);
                        }
                    }
                }

                return redisConnection;
            }
        }

        public void Put<T>(string key, T data, TimeSpan? timeout = null)
        {
            try
            {
                ////var message = string.Format("Redis -> PUT[{0}]\r\n", key);
                ////Stopwatch watch = new Stopwatch();
                ////watch.Start();

                var db = RedisConnection.GetDatabase(DatabaseNo);
                ////watch.Stop();
                ////message += string.Format("  Connect: {0}ms\r\n", watch.Elapsed.TotalMilliseconds);

                ////watch.Restart();

                string value = string.Empty;
                value = SerializeObject(data);

                ////watch.Stop();
                ////message += string.Format("  Serialize: {0}ms\r\n", watch.Elapsed.TotalMilliseconds);

                ////watch.Restart();
                db.StringSet(key, value, timeout);
                ////watch.Stop();
                ////message += string.Format("  Set: {0}ms\r\n\r\n", watch.Elapsed.TotalMilliseconds);
                ////Log(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public T Get<T>(string key)
        {
            try
            {
                ////var message = string.Format("Redis -> Get[{0}]\r\n", key);
                ////Stopwatch watch = new Stopwatch();
                ////watch.Start();

                var db = RedisConnection.GetDatabase(DatabaseNo);
                ////watch.Stop();
                ////message += string.Format("  Connect: {0}ms\r\n", watch.Elapsed.TotalMilliseconds);

                ////watch.Restart();

                var value = db.StringGet(key);

                ////watch.Stop();
                ////message += string.Format("  GET: {0}ms\r\n", watch.Elapsed.TotalMilliseconds);
                ////watch.Restart();

                if (value.IsNullOrEmpty)
                {
                    if (db.KeyExists(key) == false)
                    {
                        throw new Exception("");
                    }

                    return default(T);
                }

                T result;
                result = DeserializeObject<T>(value);

                ////message += string.Format("  Deserialze: {0}ms\r\n\r\n", watch.Elapsed.TotalMilliseconds);
                ////Log(message);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return default(T);
            }
        }

      

        public void Remove(string key)
        {
            try
            {
                var db = RedisConnection.GetDatabase(DatabaseNo);
                db.KeyDelete(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

      

        private string SerializeObject<T>(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }

        private T DeserializeObject<T>(string text)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
        }

        private void Log(string message)
        {
            lock (locker)
            {
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Redis.log"), message);
            }
        }
    }
}
