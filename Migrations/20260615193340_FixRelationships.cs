using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Halls_HallsHallId",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Movies_MoviesMovieId",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_HallsHallId",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_MoviesMovieId",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "HallsHallId",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "MoviesMovieId",
                table: "Screenings");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_HallId",
                table: "Screenings",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Halls_HallId",
                table: "Screenings",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Movies_MovieId",
                table: "Screenings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Halls_HallId",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Movies_MovieId",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_HallId",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings");

            migrationBuilder.AddColumn<int>(
                name: "HallsHallId",
                table: "Screenings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesMovieId",
                table: "Screenings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_HallsHallId",
                table: "Screenings",
                column: "HallsHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MoviesMovieId",
                table: "Screenings",
                column: "MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Halls_HallsHallId",
                table: "Screenings",
                column: "HallsHallId",
                principalTable: "Halls",
                principalColumn: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Movies_MoviesMovieId",
                table: "Screenings",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId");
        }
    }
}
