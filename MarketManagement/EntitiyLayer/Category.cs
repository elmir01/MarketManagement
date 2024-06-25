using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.EntitiyLayer
{
    internal class Category
    {
        private static int newId = 1;

        public Category()
        {
            Id = newId++;
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
