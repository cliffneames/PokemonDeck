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
    public class PokemonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pokemons
        public ActionResult Index()
        {
            var pokemons = db.Pokemons.Include(p => p.Pokedex);
            return View(pokemons.ToList());
        }

        // GET: Pokemons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // GET: Pokemons/Create
        public ActionResult Create()
        {
            ViewBag.PokedexId = new SelectList(db.Pokedexes, "PokedexID", "Name");
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PokemonID,Level,Element,Name,PokedexId")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Pokemons.Add(pokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PokedexId = new SelectList(db.Pokedexes, "PokedexID", "Name", pokemon.PokedexId);
            return View(pokemon);
        }

        // GET: Pokemons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            ViewBag.PokedexId = new SelectList(db.Pokedexes, "PokedexID", "Name", pokemon.PokedexId);
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PokemonID,Level,Element,Name,PokedexId")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PokedexId = new SelectList(db.Pokedexes, "PokedexID", "Name", pokemon.PokedexId);
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokemon pokemon = db.Pokemons.Find(id);
            db.Pokemons.Remove(pokemon);
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
