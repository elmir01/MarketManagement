
using MarketManagement.BussinessLayer.Abstract;
using MarketManagement.EntitiyLayer;

namespace MarketManagement.BussinessLayer.Concrete
{
    internal class ProductManager : IProductManager
    {
        List<Product> products = new List<Product>();
        User currentUser;
        List<Product> soldProducts = new List<Product>();
        public ProductManager(User currentUser)
        {
            this.currentUser = currentUser;
        }


        public void CheckRoleSeller()
        {
            if (currentUser.Role != "Seller")
            {
                throw new UnauthorizedAccessException("Bu emeliyyati yalnız Seller edə bilər.");
            }
        }

        public void AddProduct(Product product)
        {
            if (currentUser.Role == "Admin" || currentUser.Role == "Kassir")
            {
                products.Add(product);
                Console.WriteLine($"{product.ProductName} adlı yeni mehsul əlavə edildi. Mehsul ID-si: {product.Id}");
            }
            else
            {
                Console.WriteLine("Bu emeliyyati yalniz Admin ve ya Kassir ede biler");
            }

        }

        public void UpdateProduct(int id, Product updatedProduct)
        {
            if (currentUser.Role == "Admin" || currentUser.Role == "Kassir")
            {
                var product = GetProductById(id);
                if (product != null)
                {
                    product.ProductName = updatedProduct.ProductName;
                    product.ProductPrice = updatedProduct.ProductPrice;
                    product.StockCount = updatedProduct.StockCount;
                    product.CategoryId = updatedProduct.CategoryId;
                    Console.WriteLine($"{product.ProductName} adlı mehsul yenilendi.");
                }
                else
                {
                    Console.WriteLine("Mehsul tapılmadı.");
                }
            }
            else
            {
                Console.WriteLine("Bu emeliyyati yalniz Admin ve ya Kassir ede biler");
            }
        }

        public void DeleteProduct(int id)
        {
            if (currentUser.Role == "Admin" || currentUser.Role == "Kassir")
            {
                var product = GetProductById(id);
                if (product != null)
                {
                    products.Remove(product);
                    Console.WriteLine($"{product.ProductName} adlı mehsul silindi.");
                }
                else
                {
                    Console.WriteLine("Mehsul tapılmadı.");
                }
            }
            else
            {
                Console.WriteLine("Bu emeliyyati yalniz Admin ve ya Kassir ede biler");
            }
        }
        public void SellProduct(int id)
        {
            if (currentUser.Role == "Seller")
            {
                 var product = GetProductById(id);//verilen idli mehsulu tapib getirir
            if (product != null)
            {
                products.Remove(product);
                soldProducts.Add(product);
                Console.WriteLine($"{product.ProductName} adlı mehsul satıldı və satılmış məhsullar siyahısına elave edildi.");
            }
            else
            {
                Console.WriteLine("Mehsul tapılmadı.");
            }
            }
            else
            {
                Console.WriteLine("Bu emeliyyati yanliz Seller ede biler");
            }

        }

        public void ReturnSoldProducts(int id)
        {
            if (currentUser.Role=="Kassir")
            {
                var product = GetSoldProductById(id);
                if (product != null)
                {
                    soldProducts.Remove(product);
                    products.Add(product);
                    Console.WriteLine($"{product.ProductName} adlı mehsul geri qaytarildi və mehsullar siyahısına elave edildi.");
                }
                else
                {
                    Console.WriteLine("Mehsul tapilamdi.");
                }
            }
            else
            {
                Console.WriteLine("Bu emeliyyati yanliz Kassir ede biler");
            }
        }


        public Product GetSoldProductById(int id)
        {
            for (int i = 0; i < soldProducts.Count; i++)
            {
                if (soldProducts[i].Id == id)
                {
                    Console.WriteLine($"Satılmış Mehsul: {soldProducts[i].ProductName}, Qiymət: {soldProducts[i].ProductPrice}, Stok: {soldProducts[i].StockCount}, Mehsul ID-si: {soldProducts[i].Id}");
                    return soldProducts[i];
                }
            }

            return null;
        }
        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    Console.WriteLine($"Adi: {products[i].ProductName}, Qiymet: {products[i].ProductPrice}, Stok: {products[i].StockCount}, Mehsul ID-si: {products[i].Id}, Kateqoriya ID-si: {products[i].CategoryId}");
                    return products[i];
                }
            }
            Console.WriteLine("Mehsul tapılmadı.");
            return null;
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            List<Product> categoryProducts = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].CategoryId == categoryId)
                {
                    Console.WriteLine($"Adi: {products[i].ProductName}, Qiymet: {products[i].ProductPrice}, Stok: {products[i].StockCount}, Mehsul ID-si: {products[i].Id}");
                    categoryProducts.Add(products[i]);
                }
            }
            return categoryProducts;
        }
    }
}
