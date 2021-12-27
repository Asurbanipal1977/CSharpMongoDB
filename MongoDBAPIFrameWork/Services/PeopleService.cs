using MongoDB.Driver;
using MongoDBAPIFrameWork.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace MongoDBAPIFrameWork.Services
{
    public class PeopleService : IServices
    {
        private IMongoCollection<People> _peoples;

        public PeopleService ()
        {
            PeopleSettings settings = new PeopleSettings();
            NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("PeopleSettings");
            settings.Server = section["Server"];
            settings.Database = section["Database"];
            settings.Collection = section["Collection"];

            MongoClient mongoClient = new MongoClient(settings.Server);
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
