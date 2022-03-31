using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext _context { get; set; }
        public HomeController(BowlingDbContext temp)
        {
            _context = temp;

        }

        public IActionResult Index()
        {
            var blah = _context.Bowlers
                .ToList();
            return View(blah);
        }

        [HttpGet]
        public IActionResult NewBowler()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                _context.SaveChanges();
                return View();

            }
            else
            {
                ViewBag.Teams = _context.Teams.ToList();
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _context.Teams.ToList();
            var bowler = _context.Bowlers.Single(x => x.BowlerID == id);
            return View("NewBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == id);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
