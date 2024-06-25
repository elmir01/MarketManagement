using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.EntitiyLayer
{
    internal class Product
    {
        private static int newId = 1;
        public Product()
        {
            Id = newId++;
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
    }

}
