﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuangTriKinhDoanh.Helper
{
    public class Base64StringConverter
    {
        public static string GetBase64String(string usename, string password)
        {
            string auth = usename + ":" + password;
            byte[] inArray = System.Text.UTF8Encoding.UTF8.GetBytes(auth);
            return System.Convert.ToBase64String(inArray);
        }
    }
}