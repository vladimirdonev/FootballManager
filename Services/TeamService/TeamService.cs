using FootballLeague.Data;
using FootballLeague.Models;
using FootballLeague.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private ApplicationDbContext db;
        private const string exceptionMessage = "Team With This Id Doesn't Exists";

        public TeamService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<Team> AllTeams()
        {
            return this.db.Teams.ToList();
        }

        public void Create(string name)
        {
            var team = new Team();
            team.Name = name;
            this.db.Teams.Add(team);
            this.db.SaveChanges();
        }

        public void Delete(string teamId)
        {
            var team = this.db.Teams.FirstOrDefault(x => x.Id == teamId);
            if (team == null)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
                
            this.db.Teams.Remove(team);
            this.db.SaveChanges();
        }

        public void Edit(string teamId, string name)
        {
            var team = this.db.Teams.FirstOrDefault(x => x.Id == teamId);
            if (team == null)
            {
                throw new InvalidOperationException(exceptionMessage);
            }

            team.Name = name;
            this.db.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            this.db.Update(team);
            this.db.SaveChanges();
            
        }

        public ICollection<TeamRankingViewModel> TeamsRanking()
        {
            var ranking = this.db.Teams.Select(x => new TeamRankingViewModel
            {
                TeamId = x.Id,
                TeamName = x.Name,
                Points = x.HomeMatches.Where(y => y.IsPlayed && y.HomeTeamId == x.Id)
                .Select(x => x.HomePoints).Sum() + x.AwayMatches.Where(y => y.IsPlayed && y.AwayTeamId == x.Id)
                .Select(x => x.AwayPoints).Sum()

            }).ToList();
            return ranking;
        }
    }
}
