
using MarketManagement.BussinessLayer.Concrete;
using MarketManagement.EntitiyLayer;

class Program
{
    static void Main(string[] args)
    {
        User adminUser = new User { UserName = "AdminUser", Role = "Admin" };

        UserManager userManager = new UserManager(adminUser);

        User newUser = new User { UserName = "SellerUser", Role = "Seller" };

        userManager.AddUser(newUser);

        Category newCategory = new Category {  CategoryName = "Beverages" };
        CategoryManager categoryManager = new CategoryManager(adminUser);
        ProductManager productManager = new ProductManager(adminUser);
        ProductManager productManager1 = new ProductManager(newUser); 
        categoryManager.AddCategory(newCategory);

        Product newProduct1 = new Product
        {
            ProductName = "Apple Juice",
            ProductPrice = 3.99,
            StockCount = 50,
            CategoryId = 1
        };
        Product newProduct2 = new Product
        {
            ProductName = "Fanta",
            ProductPrice = 1.99,
            StockCount = 120,
            CategoryId = 1
        };
        Product newProduct3 = new Product
        {
            ProductName = "Alma",
            ProductPrice = 2.99,
            StockCount = 100,
            CategoryId = 2
        };
        //Product updatedProduct = new Product
        //{
        //    ProductName = "Coca-Cola",
        //    ProductPrice = 4.99,
        //    StockCount = 100,
        //    CategoryId = 1
        //};
        productManager.AddProduct(newProduct1);
        productManager.AddProduct(newProduct2);
        productManager.AddProduct(newProduct3); 
        var products = productManager.GetAllProducts();
        Console.WriteLine("-------------");
        foreach (var product in products)
        {
            Console.WriteLine($"Ad: {product.ProductName}, Qiymet: {product.ProductPrice}, Stok: {product.StockCount}, Kateqoriya ID: {product.CategoryId}");
        }


    }
}
