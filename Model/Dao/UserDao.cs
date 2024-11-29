﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    internal class UserDao
    {
        OnlineShopDBContext db = null;
        public UserDao() {
            db = new OnlineShopDBContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x=>x.UserName == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
