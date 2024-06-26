﻿using CitiesManager.Core.Identity;
using CitiesManager.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = Guid.Parse("E9EE9609-7788-44D9-9995-C2B4F5C4C37E"),
                CityName = "New York",
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = Guid.Parse("A215CAF4-BA01-415A-A5A1-9CC4D7A1DDD6"),
                CityName = "London"
            });
        }
    }
}
