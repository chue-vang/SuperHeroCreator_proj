using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroCreator.Data;
using SuperHeroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroCreator.Controllers
{
    public class HeroController : Controller
    {
        public ApplicationDbContext _context;

        public HeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HeroController
        public IActionResult Index()
        {
            var heroes = _context.Heroes.ToList();
            return View(heroes);
        }

        //GET: HeroController/Details/5
        public IActionResult Details(int id)
        {

            return View();
        }

        // GET: HeroController/Create
        public IActionResult Create(Hero heroes)
        {
            _context.Heroes.Add(heroes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Edit/5
        public ActionResult Edit(int id) 
        {
           // Hero editHero = _context.Heroes.Where(e => e.Id == id).
            return View();
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
