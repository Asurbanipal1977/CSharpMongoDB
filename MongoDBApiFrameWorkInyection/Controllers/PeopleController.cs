using MongoDBApiFrameWorkInyection.Models;
using MongoDBApiFrameWorkInyection.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;

namespace MongoDBApiFrameWorkInyection.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IServices _services;

        public PeopleController()
        {
            _services = DependencyResolver.Current.GetService<IServices>();            
        }

        [System.Web.Http.HttpGet]
        public List<People> Get()
        {
            return _services.Get();
        }

        [System.Web.Http.HttpPost]
        public async Task<People> Insert(People people)
        {
            await _services.Insert(people);
            return people;
        }

        [System.Web.Http.HttpPut]
        public async Task<People> Update(People people)
        {
            await _services.Update(people.Id, people);
            return people;
        }

        [System.Web.Http.HttpDelete]
        public async Task Delete(string id)
        {
            await _services.Delete(id);
        }
    }
}
