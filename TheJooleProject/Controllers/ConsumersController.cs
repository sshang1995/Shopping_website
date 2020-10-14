using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Joole.Data;
using System.IO;
using Joole.Service;
using TheJooleProject.Models;
using System.Data.Entity.Validation;
using Microsoft.Ajax.Utilities;


namespace TheJooleProject.Controllers
{
    public class ConsumersController : Controller
    {
        private JooleDatabaseEntities db = new JooleDatabaseEntities();

        // GET: Consumers
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(Consumer user)
        {
            using (JooleDatabaseEntities db = new JooleDatabaseEntities())
            {     
                //var userDetail = db.Consumers.Where(x => x.Consumer_Name == user.Consumer_Name || x.Email == user.Consumer_Name && x.Password == user.Password).FirstOrDefault();
                if (db.Consumers.Any(x => (x.Consumer_Name == user.Consumer_Name || x.Email == user.Consumer_Name) && x.Password == user.Password))
                { 
                    ViewBag.SuccessMessage = "Login Success!";
                    return RedirectToAction("Search","Search");


                }
                else
                {
                    user.LoginErrorMessage = "Wrong Username or Password";
                    return View("Login", user);
                }
            }
            //return View("SignupPage");
        }

        public ActionResult SignupPage()
        {
            Consumer user = new Consumer();
            return View(user);
        }
        [HttpPost]
        public ActionResult SignupPage(Consumer user, HttpPostedFileBase file)
        {
            Consumer c = new Consumer();
            using (JooleDatabaseEntities db = new JooleDatabaseEntities())
            {
                if (db.Consumers.Any(x => x.Consumer_Name == user.Consumer_Name))
                {
                    ViewBag.DuplicateMessage = "User Name Already Exists.";
                    return View("SignupPage", user);
                }
                else
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        try
                        {
                            byte[] bytes = null;
                            using (var br = new BinaryReader(file.InputStream))
                            {
                                bytes = br.ReadBytes(file.ContentLength);
                            }
                            user.Consumer_image = bytes;
                            
                            ViewBag.Message = "image upload success";

                        }
                        catch
                        {
                            ViewBag.Message = "image upload failed";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "file is none";
                    }

                    // check if new entry is an invalid entry
                    try
                    {
                       
                        db.Consumers.Add(user);
                       
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.SuccessMessage = "Saved Successfully.";
                        return View("SignupPage", new Consumer());
                    }
                    catch (DbEntityValidationException)
                    {
                        // just return the view, the client-side validation 
                        // will show the user which fields haven't been filled in
                        ViewBag.ErrorMessage = "Please fill in the required fields.";
                        return View("SignupPage", user);
                    }
                }

            }

        }

    }
}





//// GET: Consumers/Details/5
//public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Consumer consumer = db.Consumer.Find(id);
//            if (consumer == null)
//            {
//                return HttpNotFound();
//            }
//            return View(consumer);
//        }

//        // GET: Consumers/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Consumers/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ConsumerID,Consumer_Name,Email,Consumer_image,Password")] Consumer consumer)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Consumer.Add(consumer);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(consumer);
//        }

//        // GET: Consumers/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Consumer consumer = db.Consumer.Find(id);
//            if (consumer == null)
//            {
//                return HttpNotFound();
//            }
//            return View(consumer);
//        }

//        // POST: Consumers/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ConsumerID,Consumer_Name,Email,Consumer_image,Password")] Consumer consumer)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(consumer).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(consumer);
//        }

//        // GET: Consumers/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Consumer consumer = db.Consumer.Find(id);
//            if (consumer == null)
//            {
//                return HttpNotFound();
//            }
//            return View(consumer);
//        }

//        // POST: Consumers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Consumer consumer = db.Consumer.Find(id);
//            db.Consumer.Remove(consumer);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
