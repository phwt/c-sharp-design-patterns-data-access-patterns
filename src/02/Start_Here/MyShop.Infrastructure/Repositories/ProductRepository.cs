using System;
using System.Linq;
using MyShop.Domain.Models;

namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext context) : base(context)
        {
        }

        public override Product Update(Product entity)
        {
            var product = context.Products.Single(p => p.ProductId == entity.ProductId);

            // override method to limit the modification to these fields only
            product.Name = entity.Name;
            product.Price = entity.Price;

            return base.Update(product);
        }
    }
}
