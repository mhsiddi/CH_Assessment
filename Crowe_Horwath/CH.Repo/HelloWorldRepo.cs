using CH.Core;
using CH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Repo
{
    public interface IHelloWordRepo
    {
        IEnumerable<HelloWorldRequest> GetHelloWorld(HelloWorldRequest request);
    }
    public class HelloWorldRepo : IHelloWordRepo
    {
        public IEnumerable<HelloWorldRequest> GetHelloWorld(HelloWorldRequest request)
        {
            List<HelloWorldRequest> HelloWorld = new List<HelloWorldRequest>();
            List<Tuple<string,object>> parameters = new List<Tuple<string,object>>();
            DataTable result = SQLHelper.ExecuteStoredProcedure("GetHelloWorld", parameters);

            HelloWorld = (from c in result.AsEnumerable()
                          select new HelloWorldRequest()
                          {
                              ID = c.Field<int>("messageid"),
                              Message = c.Field<string>("Message")
                          }).ToList();

            return HelloWorld;
        }
    }
}
