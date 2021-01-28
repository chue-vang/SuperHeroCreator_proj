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
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hero hero)
        {
            try
            {
                _context.Heroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Edit/5
        public IActionResult Edit(int id) 
        {
            Hero edit = _context.Heroes.Where(e => e.Id == id).SingleOrDefault();
            return View(edit);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hero edit)
        {
            try
            {
                _context.Heroes.Update(edit);
                _context.SaveChanges();
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
            Hero delete = _context.Heroes.Where(d => d.Id == id).SingleOrDefault();
            return View(delete);
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                _context.Heroes.Remove(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
