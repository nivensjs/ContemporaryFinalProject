using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FavoriteThingsAPI.Data;
using FavoriteThingsAPI.Models;
using Newtonsoft.Json;

namespace FavoriteThingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly FavoriteThingsDbContext _context;

        public TeamMembersController(FavoriteThingsDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
        {
            if (id == null || id == 0)
            {
                var teamMembers = await _context.TeamMembers.Take(5).ToListAsync();
                Console.WriteLine("TeamMembers: " + JsonConvert.SerializeObject(teamMembers));
                return teamMembers;
            }

            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return Ok(teamMember);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMembers", new { id = teamMember.Id }, teamMember);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamMember).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


