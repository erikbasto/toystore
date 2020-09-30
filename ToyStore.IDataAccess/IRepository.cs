using System.Collections.Generic;

namespace ToyStore.IDataAccess
{
    /// <summary>
    /// generic interface for repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}