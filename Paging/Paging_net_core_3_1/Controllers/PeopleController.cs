using DataAccessLib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            IPaginationMetadata metadata = new PaginationMetadata(peopleParameters.MaxPageSize, peopleParameters.PageNumber, peopleParameters.PageSize);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(_peopleDataAccess.GetByPaginationParameters(peopleParameters.PageNumber, peopleParameters.PageSize));
        }
    }
}