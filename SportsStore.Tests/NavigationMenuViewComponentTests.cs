using System;
using System.Collections.Generic;
using System.Text;
using SportsStore.Controllers;
using SportsStore.Components;
using SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using Xunit;
using System.Linq;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.products).Returns((new Product[] {
                 new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                 new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                 new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                 new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
                 }).AsQueryable<Product>());
            NavigationMenuViewComponent target =
            new NavigationMenuViewComponent(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)(target.Invoke()
            as ViewViewComponentResult).ViewData.Model).ToArray();
            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples",
            "Oranges", "Plums" }, results));
        }
        [Fact]
        public void Indicates_selected_Category()
        {
            var categoryToSelect = "Apples";
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.products).Returns(new Product[] {
                 new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                 new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                 new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                 new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
            }.AsQueryable<Product>());

            NavigationMenuViewComponent component = new NavigationMenuViewComponent(mock.Object);
            component.ViewComponentContext = new ViewComponentContext {
                ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                }
            };
            component.RouteData.Values["category"] = categoryToSelect;

            string result = (component.Invoke() as ViewViewComponentResult)?.ViewData["SelectedCategory"] as string;
            Assert.Equal(categoryToSelect,result);
        }
    }
}
