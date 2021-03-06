using System;
using System.Linq;

namespace MySQLApp.Models
{
    public class EFBolwersRepository : IBowlersRepository
    {
        private BowlersDBContext _context { get; set; }


        public EFBolwersRepository(BowlersDBContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;

        //CRUD functionality
        public void SaveBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
        }

    }
}
