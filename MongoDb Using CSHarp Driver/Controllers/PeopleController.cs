using Microsoft.AspNetCore.Mvc;
using Models;
using MongoDB.Driver;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb_Using_CSHarp_Driver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;
        private IPeopleStoreSettings settings;
        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        
        [HttpGet]
        public ActionResult<List<People>> Get()
        {
            return _peopleService.Get();
        }

        
        [HttpGet("{id}")]
        public ActionResult<People> Get(string id)
        {
            var person = _peopleService.Get(id);
            if (person == null) return NotFound();
            return person;
        }

        
        [HttpPost]
        public void Create([FromBody] People person)
        {

            _peopleService.Add(person);
        }

       
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] People person)
        {
            var personWithId = _peopleService.Get(id);
            if (person == null) return NotFound();
            _peopleService.Update(id, person);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var person = _peopleService.Get(id);
            if (person == null) return NotFound();
            _peopleService.Delete(id);
            return NoContent();
        }
    }
}
