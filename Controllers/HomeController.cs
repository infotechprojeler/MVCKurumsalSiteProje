using MVCKurumsalSiteProje.Data;
using MVCKurumsalSiteProje.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCKurumsalSiteProje.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        public ActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Slides = context.Slides.ToList(),
                Categories = context.Categories.ToList(),
                Posts = context.Posts.Where(p => p.IsActive && p.IsHome).ToList()
            };
            return View(model);
        }

        public PartialViewResult KategorileriGetir() // bu actiona istek gelirse
        {
            var model = context.Categories.ToList();
            return PartialView("_PartialUstMenu", model);
        }
        [Route("hakkimizda")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("iletisim")]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Contacts.Add(contact);
                    var sonuc = context.SaveChanges();
                    if (sonuc > 0)
                    {
                        TempData["Mesaj"] = "<div class='alert alert-success'>Teşekkürler.. Mesajınız Bize Ulaştı..</div>";
                    }
                }
                catch (System.Exception)
                {
                    TempData["Mesaj"] = "<div class='alert alert-danger'>Hata Oluştu! Mesajınız Gönderilemedi..</div>";
                }
            }
            return RedirectToAction("Index");
        }
    }
}