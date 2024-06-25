using MarketManagement.EntitiyLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.BussinessLayer.Abstract
{
    internal interface IProductManager
    {
        void AddProduct(Product product);
        void UpdateProduct(int id, Product updatedProduct);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> GetProductsByCategoryId(int categoryId);
    }
}
