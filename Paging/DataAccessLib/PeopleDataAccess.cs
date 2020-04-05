using Dapper;
using DataAccessLib.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLib
{
    public class PeopleDataAccess : IPeopleDataAccess
    {
        private readonly string _connectionString;

        public PeopleDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Person Add(Person item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@FirstName", item.FirstName);
                parameters.Add("@LastName", item.LastName);
                parameters.Add("@Age", item.Age);

                connection.Execute("dbo.People_Add", parameters, commandType: CommandType.StoredProcedure);

                item.Id = parameters.Get<int>("@Id");

                return item;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var parameters = new
                {
                    Id = id
                };

                connection.Execute("dbo.People_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Person> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Person>("select Id, FirstName, LastName, Age from People").ToList();
            }
        }

        public Person GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var parameter = new
                {
                    Id = id
                };

                return connection.QueryFirst<Person>("select Id, FirstName, LastName, Age from People where Id = @Id", parameter);
                //var people = connection.Query<FullPerson, EmailAddress, FullPerson>("select p.Id as Id, p.FirstName, p.LastName, p.Age, e.Id as Id, e.EmailAddress as Email from People p join EmailAddresses e on e.PersonId = p.Id where p.Id = @Id", (person, email) => { person.EmailAddress = email; return person; }, parameter, splitOn: "Id,Id");
            }
        }

        public void Update(int id, Person item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var parameters = new
                {
                    Id = id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age
                };

                connection.Execute("dbo.People_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
