using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class Match
    {
        public Match()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsPlayed = false;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsPlayed { get; set; }

        public string HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public string AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int HomePoints { get; set; }

        public int AwayPoints { get; set; }
    }
}
