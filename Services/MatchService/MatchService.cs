using FootballLeague.Data;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Services.MatchService
{
    public class MatchService : IMatchService
    {
        private ApplicationDbContext db;
        private const string exceptionMessage = "Match With This Id Doesn't Exists";

        public MatchService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void ActivateMatch(string matchId)
        {
            var match = this.db.Matches.FirstOrDefault(x => x.Id == matchId);
            if (match == null)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
               
            match.IsPlayed = true;
            this.db.Entry(match);
            this.db.Update(match);
            this.db.SaveChanges();
            
        }

        public void CreateMatch(string name, string homeTeamId, string awayTeamId, int homePoints, int awayPoints)
        {
            var match = new Match();
            match.Name = name;
            this.db.Matches.Add(match);
            this.db.SaveChanges();
        }

        public void DeleteMatch(string matchId)
        {
            var match = this.db.Matches.FirstOrDefault(x => x.Id == matchId);
            if (match == null)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
            else if(!this.IsPlayed(matchId))
            {
                try
                {
                    this.IsPlayed(matchId);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
                
            this.db.Remove(match);
            this.db.SaveChanges();            
        }

        public void EditMatch(string matchId, string name, string homeTeamId, string awayTeamId, int homePoints, int awayPoints)
        {
            var match = this.db.Matches.FirstOrDefault(x => x.Id == matchId);
            if (match == null)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
            else if (!this.IsPlayed(matchId))
            {
            }                
            match.Name = name;
            this.db.Entry(match).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            this.db.Update(match);
            this.db.SaveChanges();
        }

        public bool IsPlayed(string matchId)
        {
            var match = this.db.Matches.FirstOrDefault(x => x.Id == matchId);
            if (match == null)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
            else if(match.IsPlayed == false)
            {
                throw new InvalidOperationException("Match Not Played Yet");
            }
            else
            {
                return match.IsPlayed;
            }
        }

        public ICollection<Match> AllPlayedMatches()
        {
            return this.db.Matches.Where(x => x.IsPlayed).ToList();
        }

        public ICollection<Match> AllNotPlayedMatches()
        {
            return this.db.Matches.Where(x => !x.IsPlayed).ToList();
        }
    }
}
