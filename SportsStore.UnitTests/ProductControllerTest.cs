using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ProductControllerTest
    {
        private IProductRepository productRepository;

        [TestInitialize]
        public void CreateRepositories()
        {
            this.productRepository = this.buildMockProductRepository();
        }

        [TestMethod]
        public void CanPaginate()
        {
            ProductController controller = new ProductController(this.productRepository);
            controller.PageSize = 4;

            var vm = (ProductsListViewModel)controller.List(null, 3).Model;

            Assert.AreEqual(3, vm.PagingInfo.CurrentPage);
            Assert.AreEqual(4, vm.PagingInfo.ItemsPerPage);
            Assert.AreEqual(9, vm.PagingInfo.TotalItems);
            Assert.AreEqual(3, vm.PagingInfo.TotalPages);

            var products = vm.Products.ToArray();
            Assert.IsTrue(products.Length == 1);
            Assert.AreEqual("Bling-Bling King", products[0].Name);
        }

        [TestMethod]
        public void CanFilterProducts()
        {
            ProductController controller = new ProductController(this.productRepository);
            controller.PageSize = 2;

            var vm = (ProductsListViewModel)controller.List("Soccer", 2).Model;
            var products = vm.Products.ToArray();

            Assert.AreEqual(1, products.Length);
            Assert.AreEqual("Stadium", products[0].Name);
            Assert.AreEqual("Soccer", products[0].Category);
        }

        private IProductRepository buildMockProductRepository()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product { Name = "Kayak", Description = "A boat for none person", Category = "Watersports", Price = 275.00M },
                new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95M },
                new Product { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50M },
                new Product { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 24.95M },
                new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 795000.00M },
                new Product { Name = "Thinking Cap", Description = "Improve your brain efficiency by 75%", Category = "Chess", Price = 16.00M },
                new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Category = "Chess", Price = 29.95M },
                new Product { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75.00M },
                new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamond-studded King", Category = "Chess", Price = 1200.00M }
            });
            return mock.Object;
        }
    }
}
