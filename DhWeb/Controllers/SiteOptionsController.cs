using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DhWeb.Models;
using System.IO;

namespace DhWeb.Controllers
{
    public class SiteOptionsController : Controller
    {
        private adminDatabaseEntities db = new adminDatabaseEntities();
      

        // GET: SiteOptions
        public ActionResult Index()
        {
            return View(db.SiteOptions.ToList());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UploadFile(SiteOptions model)
        {

                HttpPostedFileBase postedFile = Request.Files[0] as HttpPostedFileBase;
                string baseUrl = "/Content/Uploaded/";
                if (postedFile.ContentLength > 0)
                {
                    //Sätt vilken adress det är till den folder som ska användas
                    string folderPath = Server.MapPath(baseUrl);
                    //Skapa foldern
                    Directory.CreateDirectory(folderPath);

                    //Koppla den skapade foldern med de nya filens namn för en url
                    string saveFileName = Server.MapPath(baseUrl + postedFile.FileName);

                    //Spara
                    postedFile.SaveAs(saveFileName);

                model.ImageUrl = baseUrl + postedFile.FileName;

                if (ModelState.IsValid)
                {
                    db.SiteOptions.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
                else
                {
                    return Content("Invalid File"); 
                }

            return View();
        }
        // GET: SiteOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteOptions siteOptions = db.SiteOptions.Find(id);
            if (siteOptions == null)
            {
                return HttpNotFound();
            }
            return View(siteOptions);
        }

        // GET: SiteOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ImageUrl")] SiteOptions siteOptions)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SiteOptions.Add(siteOptions);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(siteOptions);
        //}

        // GET: SiteOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteOptions siteOptions = db.SiteOptions.Find(id);
            if (siteOptions == null)
            {
                return HttpNotFound();
            }
            return View(siteOptions);
        }

        // POST: SiteOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageUrl")] SiteOptions siteOptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteOptions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteOptions);
        }

        // GET: SiteOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteOptions siteOptions = db.SiteOptions.Find(id);
            if (siteOptions == null)
            {
                return HttpNotFound();
            }
            return View(siteOptions);
        }

        // POST: SiteOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteOptions siteOptions = db.SiteOptions.Find(id);
            db.SiteOptions.Remove(siteOptions);
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
