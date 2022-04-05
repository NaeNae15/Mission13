using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySQLApp.Models;

namespace MySQLApp.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Filtered = RouteData?.Values["filter"];

            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct();

            return View(teams);
        }
    }
}
