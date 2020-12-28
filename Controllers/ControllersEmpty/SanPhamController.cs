using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebQuangTriKinhDoanh.GlobalVariablesWeb;
using WebQuangTriKinhDoanh.Models;
using WebQuangTriKinhDoanh.Models.mvcModels;

namespace WebQuangTriKinhDoanh.Controllers.ControllersEmpty
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*", Location = OutputCacheLocation.None)]
        public ActionResult index()
        {
            IEnumerable<mvcSanPham> empList;
          
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("SanPhams").Result;

            empList = reponse.Content.ReadAsAsync<IEnumerable<mvcSanPham>>().Result;
           
            return View(empList);

        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcSanPham sp)
        {
            if(sp.Id == null)
            {
                if (sp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                    string extension = Path.GetExtension(sp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    sp.Anh = "~/AppFiles/Images/" + fileName;
                    sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                var sanpham = new mvcSanPham() { Id = Guid.Empty, SanPhamCode = sp.SanPhamCode, DonGia = sp.DonGia, Anh = sp.Anh, MatHangId = sp.MatHangId, TenSP = sp.TenSP, NgayCapNhat = sp.NgayCapNhat };

                HttpResponseMessage reponse = GlobalVariables.WebApiClient.PostAsJsonAsync("SanPhams/PostSanPham", sanpham).Result;


                if (reponse.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Thêm Thành Công";
                }
                else
                {
                    TempData["ErrorMessage"] = "Thêm Không Thành Công";
                }
            
            }else if(sp.Id != null)
            
            {
                if (sp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                    string extension = Path.GetExtension(sp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    sp.Anh = "~/AppFiles/Images/" + fileName;
                    sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                var sanpham = new mvcSanPham() { Id = sp.Id, SanPhamCode = sp.SanPhamCode, DonGia = sp.DonGia, Anh = sp.Anh, MatHangId = sp.MatHangId, TenSP = sp.TenSP, NgayCapNhat = sp.NgayCapNhat };

                HttpResponseMessage reponse = GlobalVariables.WebApiClient.PutAsJsonAsync("SanPhams/PutSanPham/" + sp.Id, sanpham).Result;


                if (reponse.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Sữa Thành Công";
                }
                else
                {
                    TempData["ErrorMessage"] = "Sữa Không Thành Công";
                }
            }
            

            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult AddOrEdit(string Id)
        {

            if (Id != null)
            {

                mvcSanPham sanPham = new mvcSanPham();
                HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("SanPhams/GetSanPham/" + Id).Result;
                sanPham = reponse.Content.ReadAsAsync<mvcSanPham>().Result;
                HttpResponseMessage reponse1 = GlobalVariables.WebApiClient.GetAsync("MatHangs").Result;
                List<mvcMatHang> listMatHang = reponse1.Content.ReadAsAsync<List<mvcMatHang>>().Result;
                ViewBag.SkillListItem = ToSelectList(listMatHang);
                return View(sanPham);

            }
            else
            {

                HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("MatHangs").Result;
                List<mvcMatHang> listMatHang = reponse.Content.ReadAsAsync<List<mvcMatHang>>().Result;
                ViewBag.SkillListItem = ToSelectList(listMatHang);
                return View(new mvcSanPham());

            }

        }

        [NonAction]
        public SelectList ToSelectList(List<mvcMatHang> listMatHang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in listMatHang)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.TenMH,
                    Value = Convert.ToString(item.Id)
                });
            }

            return new SelectList(list, "Value", "Text");
        }

    }
}