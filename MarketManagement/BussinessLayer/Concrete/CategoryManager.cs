using MarketManagement.BussinessLayer.Abstract;
using MarketManagement.EntitiyLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.BussinessLayer.Concrete
{
    internal class CategoryManager : ICategoryManager
    {

        private List<Category> categories = new List<Category>();
        private User currentUser;

        public CategoryManager(User currentUser)
        {
            this.currentUser = currentUser;
        }

        public void AddCategory(Category category)
        {
            if (currentUser.Role != "Admin")
            {
                Console.WriteLine("Yanliz Admin kateqoriya elave ede biler");
            }

            categories.Add(category);
            Console.WriteLine($"{category.CategoryName} adlı yeni kateqoriya elave edildi.");
        }
      
    }
}
