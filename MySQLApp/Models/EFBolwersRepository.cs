using System;
using System.Linq;

namespace MySQLApp.Models
{
    public class EFBolwersRepository : IBowlersRepository
    {
        private BowlersDBContext _context { get; set; }

        public EFBolwersRepository (BowlersDBContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;
    }
}
