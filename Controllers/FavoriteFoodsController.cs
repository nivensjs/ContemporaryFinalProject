using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FavoriteThingsAPI.Data;
using FavoriteThingsAPI.Models;
using Newtonsoft.Json;

namespace FavoriteThingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFoodsController : ControllerBase
    {
        private readonly FavoriteThingsDbContext _context;

        public FavoriteFoodsController(FavoriteThingsDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteFood>>> GetFavoriteFoods(int? id)
        {
            if (id == null || id == 0)
            {
                var favoriteFoods = await _context.FavoriteFoods.Take(5).ToListAsync();
                Console.WriteLine("FavoriteFoods: " + JsonConvert.SerializeObject(favoriteFoods));
                return favoriteFoods;
            }

            var favoriteFood = await _context.FavoriteFoods.FindAsync(id);

            if (favoriteFood == null)
            {
                return NotFound();
            }

            return Ok(favoriteFood);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<FavoriteFood>> PostFavoriteFood(FavoriteFood favoriteFood)
        {
            _context.FavoriteFoods.Add(favoriteFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteFoods", new { id = favoriteFood.Id }, favoriteFood);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteFood(int id, FavoriteFood favoriteFood)
        {
            if (id != favoriteFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteFood).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteFood(int id)
        {
            var favoriteFood = await _context.FavoriteFoods.FindAsync(id);
            if (favoriteFood == null)
            {
                return NotFound();
            }

            _context.FavoriteFoods.Remove(favoriteFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

