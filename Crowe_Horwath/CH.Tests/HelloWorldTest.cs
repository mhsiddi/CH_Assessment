using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CH.Models;
using CH.Business;
using System.Collections.Generic;
using System.Linq;

namespace CH.Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        IHelloWorldService hwService;

        public HelloWorldTest()
        {
            hwService = new HelloWorldService();
        }

        public HelloWorldTest(IHelloWorldService _hwService)
        {
            hwService = _hwService;
        }

        [TestMethod]
        public void GetMessagesList()
        {
            List<HelloWorldRequest> messages = new List<HelloWorldRequest>();
            HelloWorldRequest helloWorld = new HelloWorldRequest();

            messages = hwService.GetHelloWorld(helloWorld).data.Select(s => new HelloWorldRequest() { ID = s.ID, Message = s.Message }).ToList();

            Assert.IsTrue(messages != null, "No data has been returned.");
            Assert.IsTrue(messages.Count > 0, "List is not null but returned empty results.");
            Assert.IsTrue(messages[0].Message.ToLower().Equals("hello world"));
        }
    }
}
