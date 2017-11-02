using CH.Models;
using CH.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Business
{
    public interface IHelloWorldService
    {
        HelloWorldData GetHelloWorld(HelloWorldRequest request);
    }
    public class HelloWorldService : IHelloWorldService
    {
        IHelloWordRepo hwRepo; 

        public HelloWorldService(IHelloWordRepo _hwRepo)
        {
            hwRepo = _hwRepo;
        }

        public HelloWorldService()
        {
            hwRepo = new HelloWorldRepo();
        }
        public HelloWorldData GetHelloWorld(HelloWorldRequest request)
        {
            HelloWorldData response = new HelloWorldData();
            try
            {
                response.data = hwRepo.GetHelloWorld(request);
            }
            catch(Exception ex)
            {
                // log errors if any
            }

            return response;
        }
    }
}
