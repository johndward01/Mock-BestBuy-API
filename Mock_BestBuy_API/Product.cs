using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock_BestBuy_API
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public bool OnSale { get; set; } 
        public int StockLevel { get; set; }

    }
}
