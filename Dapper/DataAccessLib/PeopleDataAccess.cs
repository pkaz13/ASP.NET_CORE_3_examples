using Dapper;
using DataAccessLib.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLib
{
    public class PeopleDataAccess : IPeopleDataAccess
    {
        private string _connectionString;

        public PeopleDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
            }
        }

        public void Update(int id, Person item)
        {
            throw new NotImplementedException();
        }
    }
}
