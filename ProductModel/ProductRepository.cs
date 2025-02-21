using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductModel
{
    public class ProductRepository : IProduct<Product>, IDisposable
    {
        private readonly ProductDBContext context;

        public ProductRepository(ProductDBContext context)
        {
            this.context = context;
        }

        public void Add(Product entity)
        {
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            context.Products.AddRange(entities);
            context.SaveChanges();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return context.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            return context.Products.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public void Remove(Product entity)
        {
            context.Products.Remove(entity);
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            context.Products.RemoveRange(entities);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Product UpdateReorderLevel(int id, int reorderLevel)
        {
            var product = context.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                product.ReorderLevel = reorderLevel;
                context.SaveChanges();
                return product;
            }
            return null;
        }
    }
}