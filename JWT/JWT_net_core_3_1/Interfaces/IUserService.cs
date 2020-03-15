using Auth0_net_core_3_1.Entities;
using System.Collections.Generic;

namespace Auth0_net_core_3_1.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
