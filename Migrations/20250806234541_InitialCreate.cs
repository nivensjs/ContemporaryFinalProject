using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteThingsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteFastFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Burgers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChickenSandwich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FriedChicken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pizza = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFastFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Protein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vegetables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fruit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dairy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSuperheroMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoriteHero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteVillain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteMovie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteTVShow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteVideoGame = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSuperheroMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteFastFoods");

            migrationBuilder.DropTable(
                name: "FavoriteFoods");

            migrationBuilder.DropTable(
                name: "FavoriteSuperheroMedia");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
