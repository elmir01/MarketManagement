using MarketManagement.EntitiyLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.BussinessLayer.Abstract
{
    internal interface ICategoryManager
    {
        public void AddCategory(Category category);
    }
}
