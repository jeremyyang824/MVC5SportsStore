using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.HasKey(p => p.ProductID);
            this.Property(p => p.Name).IsRequired().HasMaxLength(50);
            this.Property(p => p.Description).IsRequired().HasMaxLength(500);
            this.Property(p => p.Price).IsRequired().HasPrecision(18, 2);
            this.Property(p => p.Category).IsRequired().HasMaxLength(50);
        }
    }
}
