using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string name, string dojo, string language, string comments)
        {
            ViewBag.Name = name;
            ViewBag.Dojo = dojo;
            ViewBag.Language = language;
            ViewBag.Comments = comments;
            
            return View("Result");
        }
    }
}
