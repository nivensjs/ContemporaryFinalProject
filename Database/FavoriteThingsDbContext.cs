using FavoriteThingsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
                    FullName = "",
                    Birthdate = DateTime.MinValue,
                    CollegeProgram = "",
                    YearInProgram = ""
                });

            // Seed Favorite Foods
            modelBuilder.Entity<FavoriteFood>().HasData(
                new FavoriteFood
                {
                    Id = 1,
                    Protein = "",
                    Vegetables = "",
                    Fruit = "",
                    Grain = "",
                    Dairy = ""
                });

            // Seed Favorite Superhero Media
            modelBuilder.Entity<FavoriteSuperheroMedia>().HasData(
                new FavoriteSuperheroMedia
                {
                    Id = 1,
                    FavoriteHero = "",
                    FavoriteVillain = "",
                    FavoriteMovie = "",
                    FavoriteTVShow = "",
                    FavoriteVideoGame = ""
                });

            // Seed Favorite Fast Food
            modelBuilder.Entity<FavoriteFastFood>().HasData(
                new FavoriteFastFood
                {
                    Id = 1,
                    Burgers = "",
                    Fries = "",
                    ChickenSandwich = "",
                    FriedChicken = "",
                    Pizza = ""
                });
        }
    }
}




