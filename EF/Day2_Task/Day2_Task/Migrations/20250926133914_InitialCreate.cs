using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day2_Task.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ScreeningTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "ScreeningId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 2, 28, 0, 0), "Sci-Fi", "Inception" },
                    { 2, new TimeSpan(0, 2, 32, 0, 0), "Action", "The Dark Knight" },
                    { 3, new TimeSpan(0, 2, 49, 0, 0), "Sci-Fi", "Interstellar" },
                    { 4, new TimeSpan(0, 2, 34, 0, 0), "Crime", "Pulp Fiction" },
                    { 5, new TimeSpan(0, 2, 22, 0, 0), "Drama", "The Shawshank Redemption" }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "ScreeningId", "AvailableSeats", "MovieId", "ScreeningTime" },
                values: new object[,]
                {
                    { 1, 100, 1, new DateTime(2025, 9, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 100, 2, new DateTime(2025, 9, 26, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 100, 3, new DateTime(2025, 9, 26, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 100, 4, new DateTime(2025, 9, 26, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 100, 5, new DateTime(2025, 9, 26, 22, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerName", "Price", "ScreeningId", "SeatNumber" },
                values: new object[,]
                {
                    { 1, "John Doe", 10.00m, 1, 1 },
                    { 2, "Jane Smith", 12.00m, 2, 2 },
                    { 3, "Alice Johnson", 15.00m, 3, 3 },
                    { 4, "Bob Brown", 11.00m, 4, 4 },
                    { 5, "Charlie Davis", 13.00m, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScreeningId",
                table: "Tickets",
                column: "ScreeningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
