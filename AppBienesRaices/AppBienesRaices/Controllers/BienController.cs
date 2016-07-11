using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppBienesRaices.Models;

namespace AppBienesRaices.Controllers
{
    public class BienController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bien
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Bienes.ToList());
        }

        // GET: Bien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.Bienes.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }
        [Authorize(Roles = "Admin")]
        // GET: Bien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bien/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ID,Type,City,Adress,DateWhenPublish,OriginalPrice,NewPrice,ImageUrl")] Bien bien, HttpPostedFileBase ImageUrl)
        {
            try
            {
                this.FileUpload(ImageUrl, bien);
                if (ModelState.IsValid)
                {
                    db.Bienes.Add(bien);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(bien);
        }

        // GET: Bien/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.Bienes.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Bien/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ID,Type,City,Adress,DateWhenPublish,OriginalPrice,NewPrice,ImageUrl")] Bien bien, HttpPostedFileBase ImageUrl)
        {
            this.FileUpload(ImageUrl, bien);
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        // GET: Bien/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.Bienes.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Bien/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bien bien = db.Bienes.Find(id);
            db.Bienes.Remove(bien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void FileUpload(HttpPostedFileBase file, Bien bien)
        {
                    if (file != null)
                    {
                        string ImageName = System.IO.Path.GetFileName(file.FileName);
                        string physicalPath = Server.MapPath("~/Images/" + ImageName);
                        if (bien.ImageUrl.Equals(physicalPath))
                        {
                           
                        }
                        else
                        {
                            // save image in folder
                            file.SaveAs(physicalPath);
                            bien.ImageUrl = ImageName;
                        }
                    }
        }
    }
}
