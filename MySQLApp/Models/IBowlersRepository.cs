using System;
using System.Linq;

namespace MySQLApp.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }
    }
}
