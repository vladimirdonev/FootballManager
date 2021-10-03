using FootballLeague.Services.TeamService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballLeague.Controllers
{
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpPost]
        [Route("[controller]/Create")]
        public IActionResult CreateTeam(string name)
        {
            this.teamService.Create(name);
            return Ok();
        }

        [HttpPut]
        [Route("[controller]/EditTeam")]
        public IActionResult EditTeam(string id, string name)
        {
            try
            {
                this.teamService.Edit(id, name);
                return Ok();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpDelete]
        [Route("[controller]/DeleteTeam")]
        public IActionResult DeleteTeam(string id)
        {
            try
            {
                this.teamService.Delete(id);
                return Ok();
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        [HttpGet]
        [Route("[controller]/AllTeams")]
        public IActionResult AllTeams()
        {
            return Ok(this.teamService.AllTeams());
        }

        [HttpGet]
        [Route("[controller]/TeamsRanking")]
        public IActionResult TeamsRanking()
        {
            return Ok(this.teamService.TeamsRanking());
        }
    }
}
