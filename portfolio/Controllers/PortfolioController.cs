using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("portfolio")]
        public IActionResult Portfolio()
        {
            return View("Portfolio");
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}