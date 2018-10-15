using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository/* : IProductRepository*/
    {
        public IQueryable<Product> products => new List<Product>
        {
            new Product{ Name="Footbal",Price=25},
            new Product{ Name="Surf board",Price=179},
            new Product{ Name="Running shoes",Price=95}
        }.AsQueryable<Product>();
    }
}
