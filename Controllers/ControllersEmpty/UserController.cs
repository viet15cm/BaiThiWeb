using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebQuangTriKinhDoanh.GlobalVariablesWeb;
using WebQuangTriKinhDoanh.Models.mvcModels;

namespace WebQuangTriKinhDoanh.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public  ActionResult Index()
        {
                
            return View();
        }

        [HttpPost]
        public ActionResult Login(mvcUser mvcUser)
        {
            mvcToken mvcToken = null;
            var body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", mvcUser.grant_type),
                    new KeyValuePair<string, string>("Username", mvcUser.UserName),
                    new KeyValuePair<string, string>("Password", mvcUser.PassWord)
                };
            var content = new FormUrlEncodedContent(body);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsync("token", content).Result;
           

            if (response.IsSuccessStatusCode)
            {
                mvcToken = response.Content.ReadAsAsync<mvcToken>().Result;
                GetTokenRemember(mvcUser, mvcToken);
          
                return Json(mvcToken);
            }
           
          
          return Json(mvcToken);

        }

        [HttpGet]
        public ActionResult Login()
        {

            return View(new mvcUser());

        }

        [HttpGet]
        public ActionResult LogOut()
        {

            Response.Cookies["Accout"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
            Session.Abandon();
            return RedirectToAction("Login");

        }

        [NonAction]

        public void GetTokenRemember(mvcUser mvcUser, mvcToken mvcToken)
        {
           
            if (mvcUser.Remember)
            {
                Session.Abandon();
                HttpCookie cookieAccout = new HttpCookie("Accout");
                cookieAccout.HttpOnly = true;
                HttpContext.Response.Cookies.Remove("Accout");
                cookieAccout.Value = mvcToken.access_token;
                cookieAccout.Expires = DateTime.Now.AddDays(2);
                HttpContext.Response.SetCookie(cookieAccout);
              

                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies.Get("Accout").Value);
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users/GetUserName").Result;
                if (response.IsSuccessStatusCode)
                {
                    HttpCookie cookieName = new HttpCookie("Name");
                    cookieName.HttpOnly = true;
                    HttpContext.Response.Cookies.Remove("Name");
                    cookieName.Value = response.Content.ReadAsAsync<string>().Result;
                    cookieName.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.SetCookie(cookieName);

                }

              

            }
            else
            {
                Response.Cookies["Accout"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);

                Session["Accout"] = mvcToken.access_token;

                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Accout"].ToString());
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users/GetUserName").Result;
                if (response.IsSuccessStatusCode)
                {
                    Session["Name"] = response.Content.ReadAsAsync<string>().Result;

                   
                }
            }
        }

        


    }
}