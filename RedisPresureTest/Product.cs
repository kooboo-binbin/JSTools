using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsStock { get; set; }
        public int Stock { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool ShowDiscountPrice { get; set; }
        public int DeliveryNumber { get; set; }
        public string DutchDeliverUnit { get; set; }
        public string ThumbImgPath { get; set; }
        public string ShoppingCartImgPath { get; set; }
        public decimal ActualPrice { get; set; }
        public string BrandName { get; set; }
        public decimal MeasuringPrice { get; set; }
        public bool ShowMeasuringPrice { get; set; }
        public int? BrandId { get; set; }
        public int? MeasuringUnitId { get; set; }
        public string MeasuringUnit { get; set; }
        public int? LimitedCountPerOrder { get; set; }
    }
}
