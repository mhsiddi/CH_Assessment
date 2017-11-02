using CH.Business;
using CH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crowe_Horwath.Controllers
{
    [Route("api/HelloWorld")]
    public class HelloWorldController : Controller
    {
        IHelloWorldService hwService;

        public HelloWorldController()
        {
            hwService = new HelloWorldService();
        }

        public HelloWorldController(IHelloWorldService _hwService)
        {
            hwService = _hwService;
        }

        public ActionResult GetHelloWorld()
        {
            List<HelloWorldRequest> messages = new List<HelloWorldRequest>();
            HelloWorldRequest request = new HelloWorldRequest();

            try
            {
                messages = hwService.GetHelloWorld(request).data
                    .Select(w => new HelloWorldRequest() { ID = w.ID, Message = w.Message}).ToList();
            }

            catch(Exception ex)
            {

            }
            
            return Json(messages, JsonRequestBehavior.AllowGet);
        }
        // GET: HelloWorld
        public ActionResult Index()
        {
            List<HelloWorldRequest> messages = new List<HelloWorldRequest>();
            HelloWorldRequest request = new HelloWorldRequest();

            try
            {
                messages = hwService.GetHelloWorld(request).data
                    .Select(w => new HelloWorldRequest() { ID = w.ID, Message = w.Message }).ToList();
            }

            catch (Exception ex)
            {

            }
            return View(messages);
        }
    }
}