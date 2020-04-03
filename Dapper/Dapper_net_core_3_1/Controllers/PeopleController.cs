using DataAccessLib;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_net_core_3_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleDataAccess _peopleDataAccess;

        public PeopleController(IPeopleDataAccess peopleDataAccess)
        {
            _peopleDataAccess = peopleDataAccess;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_peopleDataAccess.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_peopleDataAccess.GetById(id));
        }
    }
}