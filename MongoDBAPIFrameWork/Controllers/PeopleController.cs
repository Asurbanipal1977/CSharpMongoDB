using MongoDBAPIFrameWork.Models;
using MongoDBAPIFrameWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MongoDBAPIFrameWork.Controllers
{
    public class PeopleController : ApiController
    {
        private IServices _services;
        public PeopleController()
        {
            _services = new PeopleService();
        }

        [HttpGet]
        public List<People> Get()
        {
            return _services.Get();
        }

        [HttpPost]
        public async Task<People> Insert(People people)
        {
            await _services.Insert(people);
            return people;
        }

        [HttpPut]
        public async Task<People> Update(People people)
        {
            await _services.Update(people.Id, people);
            return people;
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _services.Delete(id);
        }
    }
}
