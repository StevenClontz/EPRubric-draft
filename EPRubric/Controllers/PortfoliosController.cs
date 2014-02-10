using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPRubric.Models;

namespace EPRubric.Controllers
{
    public class PortfoliosController : Controller
    {
        private PortfolioDBContext db = new PortfolioDBContext();

        //
        // GET: /Portfolios/

        public ActionResult Index()
        {
            return View(db.Portfolios.ToList());
        }

        //
        // GET: /Portfolios/Details/5

        public ActionResult Details(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Portfolios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Portfolios.Add(portfolio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }

        //
        // GET: /Portfolios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}