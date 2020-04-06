using DataAccessLib;
using Microsoft.AspNetCore.Mvc;

namespace Paging_net_core_3_1.Controllers
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
        public IActionResult GetPeople([FromQuery] PeopleParameters peopleParameters)
        {
            return Ok(_peopleDataAccess.GetByPaginationParameters(peopleParameters.PageNumber, peopleParameters.PageSize));
        }
    }
}