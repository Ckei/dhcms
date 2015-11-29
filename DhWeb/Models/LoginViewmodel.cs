using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DhWeb.Models
{
    public class LoginViewmodel
    {
        adminDatabaseEntities dbModel = new adminDatabaseEntities();

        public bool IsUserAdmin(string username, string password) {
            Admin user = dbModel.Admin.SingleOrDefault(o => o.username == username && o.password == password);
            //var userInDB = dbModel.Admin.Where(o => o.username == username && o.password == password);
            if (user != null)
            {
            
                return true;
            }
            else
                return false;
          
           
        }

    }
}