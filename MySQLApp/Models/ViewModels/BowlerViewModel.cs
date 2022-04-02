using System;
using System.Linq;

namespace MySQLApp.Models.ViewModels
{
    public class BowlerViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
