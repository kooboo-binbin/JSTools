﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    public class TestorBig : AbstractTestor
    {
        public List<ProductModel> _products;
        public TestorBig()
        {
            _products = GetProducts();
        }

        public override void Test()
        {

            var langauges = new string[] { "nl-nl", "en-us", "de-de" };
            for (int i = 0; i < 300; i++)//100shops
            {
                for (int j = 0; j < 3; j++) //3 languages
                {
                    try
                    {
                        //Thread.Sleep(1 * 1000);
                        var client = RedisManager.GetCacheClient();
                        var key = string.Format("NewestProducts:{0}:{1}", i, langauges[j]);
                        var data = client.Get<CachedValue<List<ProductModel>>>(key);
                        Console.WriteLine(string.Format("Read {0} {1}:{2}", TaskName, i, j));
                        if (data == null)
                        {
                            var cachedValue = new CachedValue<List<ProductModel>>() { Value = _products };

                            client.Set(key, cachedValue);
                            //Console.WriteLine(string.Format("Write{0}:{1}", i, j));
                        }


                        client.Remove(key);
                        Console.WriteLine(string.Format("Remove{0}:{1}", i, j));

                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine("Error" + ex.ToString());
                    }
                }
            }
        }


        public override List<ProductModel> GetProducts()
        {

            var list = new List<ProductModel>();
            for (int i = 0; i < 5000; i++)
            {
                list.Add(GetProduct());
            }
            return list;

        }

    }
}
