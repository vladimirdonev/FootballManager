using System;
using System.Collections.Generic;

namespace FootballLeague.Models
{
    public class Team
    {
        public Team()
        {
            this.Id = Guid.NewGuid().ToString();
            this.HomeMatches = new List<Match>();
            this.AwayMatches = new List<Match>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Match> HomeMatches { get; set; }

        public virtual ICollection<Match> AwayMatches { get; set; }
    }
}
