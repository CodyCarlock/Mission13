using Microsoft.AspNetCore.Mvc;
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

        private IBowlersRepository repo { get; set;}
        private ITeamsRepository repo2 { get; set; }
        public int BowlerId { get; set; }
        public HomeController(IBowlersRepository temp, ITeamsRepository temp2)
        {
            repo = temp;
            repo2 = temp2;
        }

        [HttpGet]
        public IActionResult Index(int team)
        {
            var bowl = repo.Bowlers
                .Where(b => b.TeamID == team || team == 0)
                .ToList();

            if (team == 0)
            {
                ViewBag.Header = "ALL Teams";
            }
            else
            {
                ViewBag.Header = repo2.Teams.Single(x => x.TeamID == team).TeamName;
            }

            return View(bowl);
        }

        [HttpGet]
        public IActionResult addBowler()
        {
            ViewBag.Bowlers = repo.Bowlers.ToList();
            return View("addBowler");
        }

        [HttpPost]
        public IActionResult addBowler(Bowler b)
        {
            
            repo.AddBowler(b);
            repo.SaveBowler(b);

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bowl = repo.Bowlers.Single(x => x.BowlerID == id);

            return View("addBowler", bowl);
        }

        [HttpPost]
        public IActionResult Edit (Bowler b)
        {
            repo.SaveBowler(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowl = repo.Bowlers.Single(x => x.BowlerID == id);
            repo.DeleteBowler(bowl);
            return RedirectToAction("Index");
        }

        
    }
}
