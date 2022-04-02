using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySQLApp.Models;
using MySQLApp.Models.ViewModels;

namespace MySQLApp.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(String TeamName, int pageNum = 1)
        {
            int pageSize = 10;
            //List<Team> teams = _repo.Teams.ToList();

            //List<Bowler> bowlers = _repo.Bowlers
            //    .OrderBy(x => x.TeamID)
            //    .ToList();
            ////return View(bowlers);

            //string teamName = TeamName;

            var x = new BowlerViewModel
            {
                Bowlers = _repo.Bowlers
                //.Where(b => b.TeamID == Team.TeamId || teamId.ToString() == null)
                .OrderBy(b => b.BowlerLastName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumTeams = (TeamName.ToString() == null
                    ? _repo.Bowlers.Count()
                    : _repo.Bowlers.Where(b => b.TeamID < 0).Count()),
                    BowlersPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
            
        }
    }
}