using MongoDBApiFrameWorkInyection.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBApiFrameWorkInyection.Services
{
    public interface IServices
    {
        List<People> Get();
        Task<People> Insert(People people);

        Task<People> Update(string id, People people);

        Task Delete(string id);
    }
}
