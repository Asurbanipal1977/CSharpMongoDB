using MongoDBAPI2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI2.Services
{
    public interface IServices
    {
        List<People> Get();
        Task<People> Insert(People people);

        Task<People> Update(string id, People people);

        Task Delete(string id);
    }
}
