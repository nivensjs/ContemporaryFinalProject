using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FavoriteThingsAPI.Data;
using FavoriteThingsAPI.Models;
using Newtonsoft.Json;

namespace FavoriteThingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteSuperheroMediaController : ControllerBase
    {
        private readonly FavoriteThingsDbContext _context;

        public FavoriteSuperheroMediaController(FavoriteThingsDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteSuperheroMedia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteSuperheroMedia>>> GetFavoriteSuperheroMedia(int? id)
        {
            if (id == null || id == 0)
            {
                var superheroMedia = await _context.FavoriteSuperheroMedia.Take(5).ToListAsync();
                Console.WriteLine("SuperheroMedia: " + JsonConvert.SerializeObject(superheroMedia)); // Debugging log
                return superheroMedia;
            }

            var favoriteSuperheroMedia = await _context.FavoriteSuperheroMedia.FindAsync(id);

            if (favoriteSuperheroMedia == null)
            {
                return NotFound();
            }

            return Ok(favoriteSuperheroMedia);
        }

        // POST: api/FavoriteSuperheroMedia
        [HttpPost]
        public async Task<ActionResult<FavoriteSuperheroMedia>> PostFavoriteSuperheroMedia(FavoriteSuperheroMedia favoriteSuperheroMedia)
        {
            _context.FavoriteSuperheroMedia.Add(favoriteSuperheroMedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteSuperheroMedia", new { id = favoriteSuperheroMedia.Id }, favoriteSuperheroMedia);
        }

        // PUT: api/FavoriteSuperheroMedia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteSuperheroMedia(int id, FavoriteSuperheroMedia favoriteSuperheroMedia)
        {
            if (id != favoriteSuperheroMedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteSuperheroMedia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/FavoriteSuperheroMedia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteSuperheroMedia(int id)
        {
            var favoriteSuperheroMedia = await _context.FavoriteSuperheroMedia.FindAsync(id);
            if (favoriteSuperheroMedia == null)
            {
                return NotFound();
            }

            _context.FavoriteSuperheroMedia.Remove(favoriteSuperheroMedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


