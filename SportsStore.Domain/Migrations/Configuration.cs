using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SportsStore.Domain.SportsStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsStore.Domain.SportsStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Products.AddOrUpdate(
                p => p.ProductID,
                new Product { Name = "Kayak", Description = "A boat for none person", Category = "Watersports", Price = 275.00M },
                new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95M },
                new Product { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50M },
                new Product { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 24.95M },
                new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 795000.00M },
                new Product { Name = "Thinking Cap", Description = "Improve your brain efficiency by 75%", Category = "Chess", Price = 16.00M },
                new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Category = "Chess", Price = 29.95M },
                new Product { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75.00M },
                new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamond-studded King", Category = "Chess", Price = 1200.00M }
            );
            context.SaveChanges();
            
        }
    }
}
