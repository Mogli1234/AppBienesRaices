using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppBienesRaices.Models;
using System.Net.Mail;

namespace AppBienesRaices.Controllers
{
    public class ContactosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contactos
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Contactos.ToList());
        }

        // GET: Contactos/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactos.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: Contactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Email,Mensaje")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Contactos.Add(contacto);
                db.SaveChanges();
                sendMail(contacto.Mensaje,contacto.Email);
                return RedirectToAction("Home");
            }

            return View(contacto);
        }

        private void sendMail(string message, string correo)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(Properties.Resources.EmailCredential);
            msg.To.Add(new MailAddress(correo));
            msg.Subject = "A new contact message from " + correo;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, System.Net.Mime.MediaTypeNames.Text.Plain));
            //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, System.Net.Mime.MediaTypeNames.Text.Html));
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(Properties.Resources.EmailCredential, Properties.Resources.PasswordCredential);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
        }

        // GET: Contactos/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactos.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,Mensaje")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacto);
        }

        // GET: Contactos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactos.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto contacto = db.Contactos.Find(id);
            db.Contactos.Remove(contacto);
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
    }
}
