using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FavoriteThingsAPI.Data;
using FavoriteThingsAPI.Models;
using Newtonsoft.Json;

namespace FavoriteThingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFastFoodsController : ControllerBase
    {
        private readonly FavoriteThingsDbContext _context;

        public FavoriteFastFoodsController(FavoriteThingsDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteFastFood>>> GetFavoriteFastFoods(int? id)
        {
            if (id == null || id == 0)
            {
                var foods = await _context.FavoriteFastFoods.Take(5).ToListAsync();
                Console.WriteLine("Foods: " + JsonConvert.SerializeObject(foods));
                return foods;
            }

            var favoriteFastFood = await _context.FavoriteFastFoods.FindAsync(id);

            if (favoriteFastFood == null)
            {
                return NotFound();
            }

            return Ok(favoriteFastFood);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<FavoriteFastFood>> PostFavoriteFastFood(FavoriteFastFood favoriteFastFood)
        {
            _context.FavoriteFastFoods.Add(favoriteFastFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteFastFoods", new { id = favoriteFastFood.Id }, favoriteFastFood);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteFastFood(int id, FavoriteFastFood favoriteFastFood)
        {
            if (id != favoriteFastFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteFastFood).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteFastFood(int id)
        {
            var favoriteFastFood = await _context.FavoriteFastFoods.FindAsync(id);
            if (favoriteFastFood == null)
            {
                return NotFound();
            }

            _context.FavoriteFastFoods.Remove(favoriteFastFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


