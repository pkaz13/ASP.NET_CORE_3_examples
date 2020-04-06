using DataAccessLib.Model;
using System.Collections.Generic;

namespace DataAccessLib
{
    public interface IPeopleDataAccess : IDataAccess<Person>
    {
        List<Person> GetByPaginationParameters(int pageNumber, int pageSize);
    }
}
