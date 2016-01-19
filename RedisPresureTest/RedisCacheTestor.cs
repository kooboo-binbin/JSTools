using GoBear.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    public class RedisCacheTestor
    {
        public string TaskName { get; set; }
        public List<ProductModel> _products;
        public RedisCacheTestor()
        {
            _products = GetProducts();
        }
        private static RedisCache client = new RedisCache();

        public void Test()
        {
            
            var langauges = new string[] { "nl-nl", "en-us", "de-de" };
            for (int i = 0; i < 300; i++)//100shops
            {
                for (int j = 0; j < 3; j++) //3 languages
                {
                    try
                    {
                        var key = string.Format("NewestProducts:{0}:{1}", i, langauges[j]);
                        var data = client.Get<CachedValue<List<ProductModel>>>(key);
                        Console.WriteLine(string.Format("Read {0} {1}:{2}", TaskName, i, j));
                        if (data == null)
                        {
                            var cachedValue = new CachedValue<List<ProductModel>>() { Value = _products };

                            client.Put(key, cachedValue);
                            //Console.WriteLine(string.Format("Write{0}:{1}", i, j));
                        }


                        //client.Remove(key);
                        Console.WriteLine(string.Format("Remove{0}:{1}", i, j));

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Error" + ex.ToString());
                    }
                }
            }
        }

        public static ProductModel GetProduct()
        {
            var model = new ProductModel();
            model.ActualPrice = 5646;
            model.BrandId = 456;
            model.BrandName = "bathroom";
            model.DeliveryNumber = 5;
            model.Description = "You have not configured a web endpoint for monitoring. Configure one to get started. You have not configured a web endpoint for monitoring. Configure one to get started. You have not configured a web endpoint for monitoring. Configure one to get started. ";
            model.DiscountPrice = 55;
            model.DutchDeliverUnit = "days";
            model.Id = 999;
            model.IsStock = true;
            model.LimitedCountPerOrder = 23;
            model.MeasuringPrice = 64;
            model.MeasuringUnit = "kg";
            model.MeasuringUnitId = 456;
            model.Name = "paper";
            model.ShoppingCartImgPath = "asf";
            model.ShowDiscountPrice = true;
            model.ShowMeasuringPrice = true;
            model.Stock = 1000;
            model.ThumbImgPath = "sdfsdfsdf/sdfsdf/sdf/sf";
            model.UnitPrice = 56;
            return model;
        }

        public  List<ProductModel> GetProducts()
        {

            var list = new List<ProductModel>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(GetProduct());
            }
            return list;

        }

    }
}
