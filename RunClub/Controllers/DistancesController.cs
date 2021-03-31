using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using RunClub.Models;



namespace Runclub.Controllers
{
    public class DistancesController : Controller
    {
        private distancesDBEntities data = new distancesDBEntities();

        // GET: Invoices
        public ActionResult Index()
        {
            return View(data.Distances.ToList());
        }


        public ActionResult Details(int? id)
        {
            Distance distance = data.Distances.Find(id);
            return RedirectToAction("EmailInvoice", "Invoices");
        }

        public ActionResult Generate()
        {
            return View();
        }

        public ActionResult PrintCertificate()
        {
            var q = new ViewAsPdf("Generate");
           
            return q;
        }

        public ActionResult SuccessInvoice()
        {
            return View();
        }
        // GET: Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistanceID,FullName,DistanceCompleted,WalkOrRun,Time")] Distance distance)
        {
            string fullName = "", walkOrRun = "", Time = "";
            double distanceCompleted = 0;
            if (ModelState.IsValid)
            {
                data.Distances.Add(distance);
                data.SaveChanges();
                fullName = distance.FullName;
                walkOrRun = distance.WalkOrRun;
                Time = distance.Time;
                distanceCompleted = Convert.ToDouble(distance.DistanceCompleted);

                Session["FullName"] = fullName;
                Session["WalkOrRun"] = walkOrRun;
                Session["Time"] = Time;
                Session["Distance"] = distanceCompleted;
                return RedirectToAction("Generate");
            }
            return View(distance);
        }


        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance distance = data.Distances.Find(id);
            if (distance == null)
            {
                return HttpNotFound();
            }
            return View(distance);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistanceID,FullName,DistanceCompleted,WalkOrRun,Time")] Distance distance)
        {
            if (ModelState.IsValid)
            {
                data.Entry(distance).State = EntityState.Modified;
                data.SaveChanges();               
                return RedirectToAction("Index");
            }
            return View(distance);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance distance= data.Distances.Find(id);
            if (distance == null)
            {
                return HttpNotFound();
            }
            return View(distance);
        }

        // POST: Invoices/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Distance distance = data.Distances.Find(id);
        //    data.Distances.Remove(distance);
        //    data.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        data.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
