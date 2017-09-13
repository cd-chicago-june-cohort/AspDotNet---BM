using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            // To retrieve an int from session we use ".GetInt32"
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");
            
            string msg = HttpContext.Session.GetString("msg");
            
            // check session
            if (fullness == null || happiness == null)
            {
                // set initial values
                fullness = 20;
                happiness = 20;
                meals = 3;
                energy = 50;
                
                // put them in session
                HttpContext.Session.SetInt32("fullness", (int)fullness);
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetInt32("energy", (int)energy);

                msg = "Push buttons and try not to kill your only friend.";
            }

            ViewBag.fullness = fullness;
            ViewBag.happiness = happiness;
            ViewBag.meals = meals;
            ViewBag.energy = energy;
            ViewBag.msg = msg;

            // WIN condition
            if (energy > 100 && fullness > 100 && happiness > 100)
            {
                msg = "You Win?  Now, go play outside.";
                return RedirectToAction("reset");
            }

            // LOSE condition
            if (fullness == 0 || happiness == 0) 
            {
                msg = "Your imaginary pet has died.  Now go outside and play.";
                return RedirectToAction("reset");
            }

            return View("index");

        }

        [HttpGet]
        [Route("eat")]
        public IActionResult eat()
        {
            Random randNum = new Random();

            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");

            // 25% chance it won't like the food, little prick.
            int likey = randNum.Next(1, 101);
            int food = randNum.Next(5,11);

            // no food/no eat
            if (meals < 1)
            {
                HttpContext.Session.SetString("msg", "How can you have any pudding if you don't eat your meat?");

            } else if (randNum.Next(1,101) < 26)
            {
                HttpContext.Session.SetString("msg", "Dojodachi no likey his lunch.");
                HttpContext.Session.SetInt32("meals", (int)(meals-1));
            } else 
            {
                HttpContext.Session.SetString("msg", "You have fed your imaginary pet " + food + " foods.  Now go outside and play.");
                HttpContext.Session.SetInt32("meals", (int)(meals-1));
                HttpContext.Session.SetInt32("fullness", (int)(fullness+food));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("play")]
        public IActionResult play()
        {
            Random randNum = new Random();

            int? energy = HttpContext.Session.GetInt32("energy");
            int? happiness = HttpContext.Session.GetInt32("happiness");

            int likey = randNum.Next(1, 101);
            int funPills = randNum.Next(5,11);

            if (energy < 5)
            {
                HttpContext.Session.SetString("msg", "Dojodachi mucho sleepy.");
            } else if (likey > 75)
            {
                HttpContext.Session.SetString("msg", "Bad touch, I'm telling.");
                HttpContext.Session.SetInt32("energy", (int)(energy - 5));
            } else
            {
                HttpContext.Session.SetString("msg", "Happy Dojodachi munch " + funPills + " fun pills.");
                HttpContext.Session.SetInt32("happiness", (int)(happiness) + funPills);
                HttpContext.Session.SetInt32("energy", (int)(energy-5));
            }

            return RedirectToAction("index");

        }

        [HttpGet]
        [Route("work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");

            int payday = rand.Next(1,4);

            if (energy <5){
                HttpContext.Session.SetString("msg", "Dojodachi lazy, no work.");
            } else {
                
                HttpContext.Session.SetInt32("meals", (int)(meals) + payday);
                HttpContext.Session.SetInt32("energy", (int)(energy-5));
                HttpContext.Session.SetString("msg", "You've earned " + payday + " meals.  You should have been a rapper.");
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");

            HttpContext.Session.SetInt32("energy", (int)(energy+15));
            HttpContext.Session.SetInt32("fullness", (int)(fullness-5));
            HttpContext.Session.SetInt32("happiness", (int)(happiness-5));
            HttpContext.Session.SetString("msg", "Rock-a-Bye, baby, you ALL rested up.");
            
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}