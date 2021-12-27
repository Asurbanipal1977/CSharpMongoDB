using MongoDB.Driver;
using MongoDBAPI2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI2.Services
{
    public class PeopleService : IServices
    {
        private IMongoCollection<People> _peoples;

        public PeopleService (ISettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Database);
            _peoples = database.GetCollection<People>(settings.Collection);
            //var mongoSetting = MongoClientSettings.FromConnectionString(settings.Server);
            //mongoSetting.ConnectTimeout = System.TimeSpan.FromSeconds(45);
            //var cliente = new MongoClient(settings.Server);

            //MongoClient cliente = new MongoClient(
            //    new MongoClientSettings
            //    {
            //        Servers = new List<MongoServerAddress>(){
            //            new MongoServerAddress("cluster0-shard-00-01.viws4.mongodb.net",27017),
            //            new MongoServerAddress("cluster0-shard-00-02.viws4.mongodb.net",27017),
            //            new MongoServerAddress("cluster0-shard-00-00.viws4.mongodb.net",27017)
            //        },
            //        ServerSelectionTimeout = System.TimeSpan.FromSeconds(60),
            //        Credential = MongoCredential.CreateCredential("admin", "MEAN_USER", "hkO5jv48hPZDf71Q"),
            //        ConnectTimeout = System.TimeSpan.FromSeconds(60),
            //        AllowInsecureTls = true,
            //        RetryWrites = true,
            //        ReplicaSetName = "atlas-shrkag-shard-0"

            //    }
            //);
            //MongoClient cliente = new MongoClient(
            //    new MongoClientSettings
            //    {
            //        Servers = new List<MongoServerAddress>(){
            //              new MongoServerAddress("localhost",27017),
            //        },
            //        ServerSelectionTimeout = System.TimeSpan.FromSeconds(60),
            //        ConnectTimeout = System.TimeSpan.FromSeconds(60),
            //        AllowInsecureTls = true
            //    }
            //);           
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
