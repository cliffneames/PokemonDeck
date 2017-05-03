using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PokemonDeck.Models;

namespace PokemonDeck.Controllers
{
    public class PokedexesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pokedexes
        public ActionResult Index()
        {
            return View(db.Pokedexes.ToList());
        }

        // GET: Pokedexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokedex pokedex = db.Pokedexes.Find(id);
            if (pokedex == null)
            {
                return HttpNotFound();
            }
            return View(pokedex);
        }

        // GET: Pokedexes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokedexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PokedexID,Name")] Pokedex pokedex)
        {
            if (ModelState.IsValid)
            {
                db.Pokedexes.Add(pokedex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pokedex);
        }

        // GET: Pokedexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokedex pokedex = db.Pokedexes.Find(id);
            if (pokedex == null)
            {
                return HttpNotFound();
            }
            return View(pokedex);
        }

        // POST: Pokedexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PokedexID,Name")] Pokedex pokedex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokedex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokedex);
        }

        // GET: Pokedexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokedex pokedex = db.Pokedexes.Find(id);
            if (pokedex == null)
            {
                return HttpNotFound();
            }
            return View(pokedex);
        }

        // POST: Pokedexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokedex pokedex = db.Pokedexes.Find(id);
            db.Pokedexes.Remove(pokedex);
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
