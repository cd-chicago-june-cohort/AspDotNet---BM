using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace example.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
            
        }
    }
}


// BELOW IS EXAMPLE OF JSON data to page
//         [HttpGet]
//         [Route("displayint")]
//         public JsonResult DisplayInt()
//         {
//             var AnonObject = new
//             {
//                 FirstName = "Hello",
//                 LastName = "World",
//                 Age = 101
//             };
//             return Json(AnonObject);
//         }