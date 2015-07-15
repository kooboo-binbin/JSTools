using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var redisManager = new PooledRedisClientManager(0, "127.0.0.1:6379");


            //for (int i = 0; i < 50; i++)
            //{
            //    var testor = new Testor1();
            //    testor.TaskName = "task" + i;
            //    var thread = new Thread(new ThreadStart(testor.Test));
            //    thread.Start();
            //}


            for (var j = 0; j < 10; j++)
            {
                for (int i = 0; i < 150; i++)
                {
                    var testor = new Testor2();
                    testor.TaskName = "task" + i;
                    var thread = new Thread(new ThreadStart(testor.Test));
                    thread.Start();
                }
            }
            Console.WriteLine("End");
            Console.Read();
        }




    }
}
