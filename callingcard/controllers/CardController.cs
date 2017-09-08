using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingcard.Controllers
{
    public class CardController : Controller
    {
        [HttpGet]
        [Route("{FirstName}/{LastName}/{Age}/{Color}")]
        public JsonResult test(string FirstName, string LastName, int Age, string Color)
        {
            var AnonObject = new
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Color = Color
            };
            return Json(AnonObject);
        }
    }
}
