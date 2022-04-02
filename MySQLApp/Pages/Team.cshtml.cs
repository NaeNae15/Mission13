using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySQLApp.Models;

namespace MySQLApp.Pages
{
    public class TeamModel : PageModel
    {

        private IBowlersRepository repo { get; set; }

        public TeamModel(IBowlersRepository temp)
        {
            repo = temp;
        }

        public Team team { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            team = HttpContext.Session.GetJson<Team>("team") ?? new Bowler();
        }

        public IActionResult OnPost(int bowlerId, string returnUrl)
        {
            Bowler b = repo.Bowlers.FirstOrDefault(x => x.BowlerID == bowlerId);

            team = HttpContext.Session.GetJson<Team>("team") ?? new Team();
            team.AddBowler(b, 1);

            HttpContext.Session.SetJson("team", team);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}