using FootballLeague.Services.MatchService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballLeague.Controllers
{
    [ApiController]
    public class MatchController : ControllerBase
    {
        private IMatchService matchService;

        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet]
        [Route("[controller]/AllPlayedMatches")]
        public IActionResult AllPlayedMatches()
        {
            return Ok(this.matchService.AllPlayedMatches());
        }

        [HttpGet]
        [Route("[controller]/AllNotPlayedMatches")]
        public IActionResult AllNotPlayedMatches()
        {
            return Ok(this.matchService.AllNotPlayedMatches());
        }

        [HttpPost]
        [Route("[controller]/Create")]
        public IActionResult CreateMatch(string name)
        {
            this.matchService.CreateMatch(name);
            return Ok();
        }

        [HttpPut]
        [Route("[controller]/EditMatch")]
        public IActionResult EditMatch(string macthId, string name, string homeTeamId, string awayTeamId, int homePoints, int awayPoints)
        {
            try
            {
                this.matchService.EditMatch(macthId, name, homeTeamId, awayTeamId, homePoints, awayPoints);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        [Route("[controller]/ActivateMatch")]
        public IActionResult ActivateMatch(string matchId)
        {
            try
            {
                this.matchService.ActivateMatch(matchId);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        [Route("[controller]/AddResult")]
        public IActionResult AddResult(string matchId, string homeTeamId, string awayTeamId, int homePoints, int awayPoints)
        {
            try
            {
                this.matchService.AddResult(matchId, homeTeamId, awayTeamId, homePoints, awayPoints);
                return Ok();
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
        }
        [HttpDelete]
        [Route("[controller]/DeleteMatch")]
        public IActionResult DeleteMatch(string matchId)
        {
            try
            {
                this.matchService.DeleteMatch(matchId);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
