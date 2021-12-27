using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBAPI2.Models;
using MongoDBAPI2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IServices _services;
        public PeopleController(IServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<List<People>> Get()
        {
            return _services.Get();
        }

        [HttpPost]
        public async Task<ActionResult<People>> Insert(People people)
        {
            await _services.Insert(people);
            return Ok(people);
        }

        [HttpPut]
        public async Task<ActionResult<People>> Update(People people)
        {
            await _services.Update(people.Id, people);
            return Ok(people);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _services.Delete(id);
            return Ok();
        }

    }
}
