using FootballLeague.Models;
using System.Collections.Generic;

namespace FootballLeague.Services.MatchService
{
    public interface IMatchService
    {
        void CreateMatch(string name, string homeTeamId, string awayTeamId, int homePoints, int awayPoints);

        void ActivateMatch(string matchId);

        void EditMatch(string matchId, string name, string homeTeamId, string awayTeamId, int homePoints, int awayPoints);

        void DeleteMatch(string matchId);

        bool IsPlayed(string matchId);

        ICollection<Match> AllPlayedMatches();

        ICollection<Match> AllNotPlayedMatches();
    }
}
