using MVCKurumsalSiteProje.Data;
using MVCKurumsalSiteProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCKurumsalSiteProje.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kullanici = db.Users.FirstOrDefault(k => k.Email == user.Email && k.Password == user.Password && k.IsAdmin && k.IsActive);
                    if (kullanici == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(kullanici.Email, true);
                        if (Request.QueryString["ReturnUrl"] != null) // eğer adres çubuğunda ReturnUrl değeri varsa
                        {
                            return Redirect(Request.QueryString["ReturnUrl"]); // kullanıcıyı login işleminden sonra gitmek istediği adrese yönlendir
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}