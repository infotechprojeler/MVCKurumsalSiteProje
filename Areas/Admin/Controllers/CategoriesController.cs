using MVCKurumsalSiteProje.Data;
using MVCKurumsalSiteProje.Models;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCKurumsalSiteProje.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        public ActionResult Create(Category collection, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            try
            {
                // TODO: Add insert logic here
                if (Image != null)
                {
                    collection.Image = Image.FileName;
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                }
                context.Categories.Add(collection);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) // eğer adres çubuğunda id yazılmamışsa
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // kullanıcıya geçersiz-bozuk istek yapıldı uyarısı dön.
            }
            var data = context.Categories.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category collection, HttpPostedFileBase Image)
        {
            try
            {
                // TODO: Add update logic here
                if (Image != null)
                {
                    collection.Image = Image.FileName;
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                }
                context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) // eğer adres çubuğunda id yazılmamışsa
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // kullanıcıya geçersiz-bozuk istek yapıldı uyarısı dön.
            }
            var data = context.Categories.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var data = context.Categories.Find(id);
                context.Categories.Remove(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
