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
            var tasks = new List<Task>();

            for (int i = 0; i < 50; i++)
            {
                var testor = new Testor1();
                testor.TaskName = "task" + i;
                var thread = new Thread(new ThreadStart(testor.Test));
                thread.Start();
            }

            //for (int i = 0; i < 50; i++)
            //{
            //    var testor = new Testor1();
            //    testor.TaskName = "task" + i;
            //    var task = new Task(() =>
            //    {
            //        testor.Test();
            //    });
            //    tasks.Add(task);
            //    task.Start();
            //}
            //try
            //{
            //    Task.WaitAll(tasks.ToArray());
            //}
            //catch (AggregateException exception)
            //{
            //    foreach (var item in exception.InnerExceptions)
            //    {
            //        Console.WriteLine(item.Message);
            //    }
            //}
            Console.WriteLine("End");
            Console.Read();
        }




    }
}
