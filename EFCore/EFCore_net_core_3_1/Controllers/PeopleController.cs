using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLib.DataAccess;
using DataAccessLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_net_core_3_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleContext _context;

        public PeopleController(PeopleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.People.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.People.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }
    }
}