using System;
namespace MySQLApp.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumTeams { get; set; }

        public int BowlersPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalNumTeams / BowlersPerPage);
    }
}
