using FootballLeague.Models;
using FootballLeague.ViewModels;
using System.Collections.Generic;

namespace FootballLeague.Services.TeamService
{
    public interface ITeamService
    {
        void Create(string name);

        void Edit(string teamId,string name);

        void Delete(string teamId);

        ICollection<Team> AllTeams();

        ICollection<TeamRankingViewModel> TeamsRanking();
    }
}
