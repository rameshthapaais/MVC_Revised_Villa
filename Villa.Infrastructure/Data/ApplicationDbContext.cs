using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;


namespace Villa.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villia> Villas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villia>().HasData(
                
                new Villia
                {
                    Id = 1,
                    Name = "Oceanview Retreat",
                    Location = "Malibu, CA",
                    Description = "A beautiful villa with stunning ocean views.",
                    PricePerNight = 750.00m,
                    NumberOfBedrooms = 4,
                    NumberOfBathrooms = 3,
                    HasSwimmingPool = true,
                    ImageUrl = "https://example.com/images/oceanview_retreat.jpg",
                    CreatedAt = new DateTime(2024,12,14)
                },
                new Villia
                {
                    Id = 2,
                    Name = "Mountain Escape",
                    Location = "Aspen, CO",
                    Description = "Cozy villa nestled in the mountains, perfect for a winter getaway.",
                    PricePerNight = 600.00m,
                    NumberOfBedrooms = 3,
                    NumberOfBathrooms = 2,
                    HasSwimmingPool = false,
                    ImageUrl = "https://example.com/images/mountain_escape.jpg",
                    CreatedAt = new DateTime(2024,12,14)
                },
                new Villia
                {
                    Id = 3,
                    Name = "City Lights Villa",
                    Location = "New York, NY",
                    Description = "Modern villa located in the heart of the city with breathtaking skyline views.",
                    PricePerNight = 850.00m,
                    NumberOfBedrooms = 2,
                    NumberOfBathrooms = 2,
                    HasSwimmingPool = false,
                    ImageUrl = "https://example.com/images/city_lights_villa.jpg",
                    CreatedAt = new DateTime(2024,12,14)
                }
            );
        }
    }
}
