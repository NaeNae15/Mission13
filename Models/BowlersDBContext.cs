using System;
using Microsoft.EntityFrameworkCore;

namespace MySQLApp.Models
{
    public class BowlersDBContext : DbContext
    {
        public BowlersDBContext(DbContextOptions<BowlersDBContext> options) : base (options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
