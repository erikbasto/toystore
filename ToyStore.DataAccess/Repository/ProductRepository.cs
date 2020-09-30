using System;
using System.Collections.Generic;
using System.Linq;
using ToyStore.IDataAccess;
using ToyStore.Model;

namespace ToyStore.DataAccess.Repository
{
    /// <summary>
    /// Produc repository
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        private readonly ToyStoreDbContext context;

        public ProductRepository(ToyStoreDbContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }

        public Product Create(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                context.Products.Add(entity);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return entity;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                var item = context.Products.Find(id);
                if (item != null)
                {
                    context.Products.Remove(item);
                    int affectedRows = context.SaveChanges();
                    result = affectedRows > 0;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public IList<Product> GetAll()
        {
            try
            {
                return context.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return context.Products.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public Product Update(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                var item = context.Products.Find(entity.Id);
                if (item != null)
                {
                    context.Products.Update(entity);
                    context.SaveChanges();
                    return entity;
                }
                return item;
            }
            catch
            {
                throw;
            }
        }
    }
}
