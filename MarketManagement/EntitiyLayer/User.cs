﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.EntitiyLayer
{
    internal class User
    {
        private static int newId = 1;

        public User()
        {
            Id = newId++;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

}
