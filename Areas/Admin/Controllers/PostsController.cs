using MVCKurumsalSiteProje.Data;
using MVCKurumsalSiteProje.Models;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCKurumsalSiteProje.Areas.Admin.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View(context.Posts.ToList());
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Posts/Create
        [HttpPost]
        public ActionResult Create(Post collection, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (Image != null)
                    {
                        collection.Image = Image.FileName;
                        Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    }
                    context.Posts.Add(collection);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Name");
            return View(collection);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = context.Posts.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Name", data.CategoryId); // buradaki son parametre ekran açılışında seçili değeri belirler.
            return View(data);
        }

        // POST: Admin/Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post collection, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
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
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Name");
            return View(collection);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = context.Posts.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Post collection)
        {
            try
            {
                // TODO: Add delete logic here
                context.Entry(collection).State = System.Data.Entity.EntityState.Deleted;
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
