using MVCKurumsalSiteProje.Data;
using MVCKurumsalSiteProje.Models;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCKurumsalSiteProje.Areas.Admin.Controllers
{
    public class SlidesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Slides
        public ActionResult Index()
        {
            return View(context.Slides.ToList());
        }

        // GET: Admin/Slides/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slides/Create
        [HttpPost]
        public ActionResult Create(Slide collection, HttpPostedFileBase Image)
        {
            try
            {
                // TODO: Add insert logic here
                if (Image != null)
                {
                    collection.Image = Image.FileName;
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                }
                context.Slides.Add(collection);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }

        // GET: Admin/Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = context.Slides.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Admin/Slides/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Slide collection, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: Admin/Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = context.Slides.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Slide collection)
        {
            try
            {
                // TODO: Add delete logic here
                var data = context.Slides.Find(id);
                if (data != null)
                {
                    context.Slides.Remove(data);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
