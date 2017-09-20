using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccts.Models;
using System.Linq;

namespace BankAccts.Controllers
{
    public class HomeController : Controller
    {

        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("processLogin")]
        public IActionResult processLogin(LoginViewModel isUser)
        {
            
        }
    }
}
