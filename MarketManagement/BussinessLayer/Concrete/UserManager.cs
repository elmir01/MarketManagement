using MarketManagement.BussinessLayer.Abstract;
using MarketManagement.EntitiyLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.BussinessLayer.Concrete
{
    internal class UserManager : IUserManager
    {
        private List<User> users = new List<User>();
        private User currentUser;

        public UserManager(User currentUser)
        {
            this.currentUser = currentUser;
        }

        public void AddUser(User user)
        {
            if (currentUser.Role != "Admin")
            {

                Console.WriteLine("Yanliz admin istifadeci elave ede biler");
            }

            if (user.Role != "Admin" && user.Role != "Seller" && user.Role != "Kassir")
            {
                Console.WriteLine("Duzgun rol girin");
            }

            users.Add(user);
        }

    }
}
