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
            //var testorGetAll = new TestorGetAll();
            //testorGetAll.Test();

            var testor = new RedisCacheTestor();

            for (int i = 0; i < 1; i++)
            {

                testor.TaskName = "task" + i;
                var thread = new Thread(new ThreadStart(testor.Test));
                thread.Start();
            }

            //var testor = new TestorBig();

            //for (int i = 0; i < 100; i++)
            //{

            //    testor.TaskName = "task" + i;
            //    var thread = new Thread(new ThreadStart(testor.Test));
            //    thread.Start();
            //}


            //for (var j = 0; j < 10; j++)
            //{
            //    for (int i = 0; i < 150; i++)
            //    {
            //        var testor = new Testor2();
            //        testor.TaskName = "task" + i;
            //        var thread = new Thread(new ThreadStart(testor.Test));
            //        thread.Start();
            //    }
            //}
            Console.WriteLine("End");
            Console.Read();
        }


        private void TestGetAll()
        { 
        
        }

    }
}
