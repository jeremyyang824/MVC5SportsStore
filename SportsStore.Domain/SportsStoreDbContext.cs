using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Domain.EntityConfigurations;
using System.Data.Entity.Migrations;
namespace SportsStore.Domain
{
    public class SportsStoreDbContext : DbContext
    {
        public SportsStoreDbContext()
            : base("SportsStore")
        {
            Database.SetInitializer<SportsStoreDbContext>(null);   //不自动创建数据库
        }

        public IDbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  //单数形式表名

            //数据表配置
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
