using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day2_Task.Models;

namespace Day2_Task.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Screening> Screenings { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Cinema;Integrated Security=SSPI;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Inception", Duration = TimeSpan.FromMinutes(148), Genre = "Sci-Fi" },
                new Movie { MovieId = 2, Title = "The Dark Knight", Duration = TimeSpan.FromMinutes(152), Genre = "Action" },
                new Movie { MovieId = 3, Title = "Interstellar", Duration = TimeSpan.FromMinutes(169), Genre = "Sci-Fi" },
                new Movie { MovieId = 4, Title = "Pulp Fiction", Duration = TimeSpan.FromMinutes(154), Genre = "Crime" },
                new Movie { MovieId = 5, Title = "The Shawshank Redemption", Duration = TimeSpan.FromMinutes(142), Genre = "Drama" }
            );

            modelBuilder.Entity<Screening>().HasData(
                new Screening { ScreeningId = 1, MovieId = 1, ScreeningTime = new DateTime(2025, 9, 26, 18, 0, 0), AvailableSeats = 100 },
                new Screening { ScreeningId = 2, MovieId = 2, ScreeningTime = new DateTime(2025, 9, 26, 19, 0, 0), AvailableSeats = 100 },
                new Screening { ScreeningId = 3, MovieId = 3, ScreeningTime = new DateTime(2025, 9, 26, 20, 0, 0), AvailableSeats = 100 },
                new Screening { ScreeningId = 4, MovieId = 4, ScreeningTime = new DateTime(2025, 9, 26, 21, 0, 0), AvailableSeats = 100 },
                new Screening { ScreeningId = 5, MovieId = 5, ScreeningTime = new DateTime(2025, 9, 26, 22, 0, 0), AvailableSeats = 100 }
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, ScreeningId = 1, CustomerName = "John Doe", SeatNumber = 1, Price = 10.00m },
                new Ticket { TicketId = 2, ScreeningId = 2, CustomerName = "Jane Smith", SeatNumber = 2, Price = 12.00m },
                new Ticket { TicketId = 3, ScreeningId = 3, CustomerName = "Alice Johnson", SeatNumber = 3, Price = 15.00m },
                new Ticket { TicketId = 4, ScreeningId = 4, CustomerName = "Bob Brown", SeatNumber = 4, Price = 11.00m },
                new Ticket { TicketId = 5, ScreeningId = 5, CustomerName = "Charlie Davis", SeatNumber = 5, Price = 13.00m }
            );

        }
        }
    }

