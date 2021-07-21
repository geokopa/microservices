using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        internal static void SeedData(IMongoCollection<Product> products)
        {
            bool existProduct = products.Find(p => true).Any();

            if (!existProduct)
            {
                products.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone 12 Mini",
                    Summary = "This phone is mine",
                    Description = "Sample description text",
                    ImageFile = "product-1.png",
                    Price = 2850.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
