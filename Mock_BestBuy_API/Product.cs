using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock_BestBuy_API
{
    public class Product
    {
        public int ProductID { get; set; }
        
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public double Price { get; set; }

        [BindProperty]
        public int CategoryID { get; set; }

        [BindProperty]
        public int OnSale { get; set; }

        [BindProperty]
        public int StockLevel { get; set; }

    }
}
