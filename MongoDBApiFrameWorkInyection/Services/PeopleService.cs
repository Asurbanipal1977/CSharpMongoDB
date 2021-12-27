using MongoDB.Driver;
using MongoDBApiFrameWorkInyection.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MongoDBApiFrameWorkInyection.Services
{
    public class PeopleService : IServices
    {
        private IMongoCollection<People> _peoples;

        public PeopleService ()
        {
            ISettings settings = DependencyResolver.Current.GetService<ISettings>();
            IMongoClient mongoClient = DependencyResolver.Current.GetService<IMongoClient>();

            var database = mongoClient.GetDatabase(settings.Database);
            _peoples = database.GetCollection<People>(settings.Collection);
        }

        public List<People> Get ()
        {
            return _peoples.Find(c=>true).ToList();
        }

        public async Task<People> Insert(People people)
        {
            await _peoples.InsertOneAsync(people);
            return people;
        }

        public async Task<People> Update(string id, People people)
        {
            await _peoples.ReplaceOneAsync(c => c.Id == id, people);
            return people;
        }

        public async Task Delete(string id)
        {
            await _peoples.DeleteOneAsync(c => c.Id == id);
        }

    }
}
