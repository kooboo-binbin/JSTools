using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    public abstract class AbstractTestor
    {
        protected static Random rnd = new Random();
        protected PooledRedisClientManager RedisManager = new PooledRedisClientManager(0, "127.0.0.1:6379");
        public abstract void Test();
        public string TaskName { get; set; }
        public List<ProductModel> GetProducts()
        {
            var list = new List<ProductModel>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(GetProduct());
            }
            return list;
        }

        public ProductModel GetProduct()
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
    }
}
