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
            var langauges = new string[] { "nl-nl", "en-us", "de-de" };
            int i = 0, j = 0;
            var client = RedisManager.GetCacheClient();
            var key = string.Format("NewestProducts3:{0}:{1}", i, langauges[j]);
            var data = client.Get<CachedValue<List<ProductModel>>>(key);
            Console.WriteLine(string.Format("Read {0} {1}:{2}", TaskName, i, j));
            if (data == null)
            {
                Thread.Sleep(1 * 3000);
                var cachedValue = new CachedValue<List<ProductModel>>() { Value = GetProducts() };

                client.Set(key, cachedValue);
                Console.WriteLine(string.Format("Write {0} {1}:{2}", TaskName, i, j));


            }
            client.Remove(key);
        }
    }
}
