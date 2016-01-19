using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    public class Testor2 : AbstractTestor
    {
        public override void Test()
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var langauges = new string[] { "nl-nl", "en-us", "de-de" };

                    var client = RedisManager.GetCacheClient();
                    var key = string.Format("NewestProducts3:{0}:{1}", 0, langauges[0]);
                    var data = client.Get<CachedValue<List<ProductModel>>>(key);
                    Console.WriteLine(string.Format("Read {0} {1}:{2}", TaskName, 0, 0));
                    if (data == null)
                    {
                        Thread.Sleep(1 * 3000);


                        Console.WriteLine(string.Format("Write {0} {1}:{2}", TaskName, 0, 0));


                    }
                    var cachedValue = new CachedValue<List<ProductModel>>() { Value = GetProducts() };
                    client.Set(key, cachedValue);
                    client.Remove(key);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
