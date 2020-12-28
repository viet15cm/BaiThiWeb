using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuangTriKinhDoanh.DBContext;
using WebQuangTriKinhDoanh.Models;

namespace WebQuangTriKinhDoanh.Helper
{
    public class UserMasterRepository  : IDisposable
    {
        DBcontextLayer context = new DBcontextLayer();
        //This method is used to check and validate the user credentials
        public User ValidateUser(string username, string password)
        {
            return context.Users.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassWord == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}