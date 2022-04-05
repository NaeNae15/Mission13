using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLApp.Models;
using MySQLApp.Models.ViewModels;

namespace MySQLApp.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        private BowlersDBContext _context { get; set; }

        public HomeController(IBowlersRepository temp, BowlersDBContext blah)
        {
            _repo = temp;
            _context = blah;
        }
        [HttpGet]
        public IActionResult Index(string filter, int pagNum = 1)
        {
            var data = _repo.Bowlers
                .Where(b => b.Team.TeamName == filter || filter == null) 
                .Include(x => x.Team)
                .ToList();

            if (filter != null)
            {
                ViewBag.Title = _repo.Bowlers.FirstOrDefault(x => x.Team.TeamName == filter);
            }
            else
            {
                ViewBag.Title = null;
            }
            ViewBag.Teams = _context.Teams.ToList();

            return View(data);
        }

        //Delete functionality
        public IActionResult DeleteBowler(int bowlerid)
        {
            var b = _repo.Bowlers.Where(x => x.BowlerID == bowlerid).FirstOrDefault();
            _repo.DeleteBowler(b);

            return RedirectToAction("Index");
        }

        //Edit functionality
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var data = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            //Call repository save method
            _repo.SaveBowler(b);
            int teams = b.TeamID;
            return RedirectToAction("Index", teams);
        }

        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var b = _repo.Bowlers.FirstOrDefault(x => x.BowlerID == id);
                _repo.DeleteBowler(b);
                return RedirectToAction("Index");
            }
            else
            {
                //Send back to view if model is not valid
                ViewBag.Teams = _context.Teams.ToList();
                return View();
            }
        }



        //Add Bowler functionality
        [HttpGet]
        public IActionResult AddBowler()
        {
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                var li = new List<int>();
                foreach (Bowler bo in _repo.Bowlers)
                {
                    li.Add(bo.BowlerID);
                }
                b.BowlerID = li.Max() + 1;
                _repo.AddBowler(b);
                return RedirectToAction("Index");
            }
            else
            {
                //Send back to view if model is not valid
                ViewBag.Teams = _context.Teams.ToList();
                return View();
            }
        }
    }
}