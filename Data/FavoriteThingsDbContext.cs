using FavoriteThingsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FavoriteThingsAPI.Data
{
    public class FavoriteThingsDbContext : DbContext
    {
        public FavoriteThingsDbContext(DbContextOptions<FavoriteThingsDbContext> options)
            : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
        public DbSet<FavoriteSuperheroMedia> FavoriteSuperheroMedia { get; set; }
        public DbSet<FavoriteFastFood> FavoriteFastFoods { get; set; }

        // Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Team Members
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember
                {
                    Id = 1,
                    FullName = "Riley Heitkamp",
                    Birthdate = new DateTime(2003, 10, 13),
                    CollegeProgram = "Contemporary Programming",
                    YearInProgram = "Junior"
                });

            // Seed Favorite Foods
            modelBuilder.Entity<FavoriteFood>().HasData(
                new FavoriteFood
                {
                    Id = 1,
                    Protein = "Beef",
                    Vegetables = "Potatoes",
                    Fruit = "Strawberries",
                    Grain = "Rice",
                    Dairy = "Cheese"
                });

            // Seed Favorite Superhero Media
            modelBuilder.Entity<FavoriteSuperheroMedia>().HasData(
                new FavoriteSuperheroMedia
                {
                    Id = 1,
                    FavoriteHero = "Batman",
                    FavoriteVillain = "Joker",
                    FavoriteMovie = "Spiderman: No Way Home",
                    FavoriteTVShow = "Loki",
                    FavoriteVideoGame = "Batman: Arkham City"
                });

            // Seed Favorite Fast Food
            modelBuilder.Entity<FavoriteFastFood>().HasData(
                new FavoriteFastFood
                {
                    Id = 1,
                    Burgers = "Culvers",
                    Fries = "McDonald's",
                    ChickenSandwich = "Wendy's",
                    FriedChicken = "Popeyes",
                    Pizza = "Dominoes"
                });
        }
    }
}


