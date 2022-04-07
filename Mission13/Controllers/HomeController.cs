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
        private IBowlersRepository _repo { get; set; }
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;

        }

        public IActionResult Index(int? teamID)
        {
            string blah = "Team Name";
            if (teamID == 1)
            {
                blah = "Marlins";
            }
            if (teamID == 2)
            {
                blah = "Sharks";
            }
            if (teamID == 3)
            {
                blah = "Terrapins";
            }
            if (teamID == 4)
            {
                blah = "Barracudas";
            }
            if (teamID == 5)
            {
                blah = "Dolphins";
            }
            if (teamID == 6)
            {
                blah = "Orcas";
            }
            if (teamID == 7)
            {
                blah = "Manatees";
            }
            if (teamID == 8)
            {
                blah = "Swordfish";
            }
            if (teamID == 9)
            {
                blah = "Hucckleberrys";
            }
            if (teamID == 10)
            {
                blah = "MintJuleps";
            }
            if (teamID == null)
            {
                var bowl = _repo.Bowlers.ToList();
                return View(bowl);
            }
            else
            {
                var bowl = _repo.Bowlers.ToList().Where(x => x.TeamID == teamID);
                return View(bowl);
            }
        }
    

        [HttpGet]
        public IActionResult NewBowler()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult NewBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(b);

                var bowl = _repo.Bowlers.ToList();
                return RedirectToAction("Index", bowl);

            }
            else
            {
                
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(b);
                
                var blah = _repo.Bowlers
                .ToList();
                return View("Index", blah);

            }
            else
            {

                return View(b);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.Delete(b);
            return RedirectToAction("Index");
        }
    }
}
