using System.Collections.Generic;

namespace DataAccessLib
{
    public interface IDataAccess<T>  where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}