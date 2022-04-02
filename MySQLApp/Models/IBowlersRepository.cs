using System;
using System.Linq;

namespace MySQLApp.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }


        //CRUD functionality
        public void SaveBowler(Bowler b);
        public void AddBowler(Bowler b);
        public void DeleteBowler(Bowler b);
    }
}
