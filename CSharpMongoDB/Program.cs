using CSharpMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpMongoDB
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var tiempo = Stopwatch.StartNew();
            var client = new MongoClient("mongodb://localhost:27017/school");
            Console.WriteLine("Se consigue la conexión:" + tiempo.ElapsedMilliseconds);
            var bd = client.GetDatabase("school");
            Console.WriteLine("Se consigue la base de datos:" + tiempo.ElapsedMilliseconds);

            var peopleCollection = bd.GetCollection<People>("people");
            Console.WriteLine("Se consigue la colección:" + tiempo.ElapsedMilliseconds);

            var people = new People() { Name = "Tere", Age = 48 };
            await peopleCollection.InsertOneAsync(people);
            Console.WriteLine("Se inserta:" + tiempo.ElapsedMilliseconds);

            await peopleCollection.Find(c => true).ForEachAsync(
                people => Console.WriteLine(people.Name)
            );
            tiempo.Stop();
            Console.WriteLine("Se lista:" + tiempo.ElapsedMilliseconds);
        }
    }
}
