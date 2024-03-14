using Microsoft.AspNetCore.Mvc;
using project3.Models;
using System.Collections.Generic;
using System.Drawing;
namespace project3.Controllers
{
    public class ShowController : Controller
    {
        public DatasiteContext ctx { get; set; }
        public ShowController(DatasiteContext ctx) { this.ctx = ctx; }
        public IActionResult Show()
        {
            if (HttpContext.Session.GetInt32("userid") == null)
                return RedirectToAction("Login", "Login");

            int? ID = HttpContext.Session.GetInt32("userid");

            User mv = ctx.Users.Find(ID);
            return View("Show", mv);
        }
        [HttpGet]
        public IActionResult Change()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Change(int Password)
        {
            if (HttpContext.Session.GetInt32("userid") == null)
                return View("Login");

            int? ID = HttpContext.Session.GetInt32("userid");
            User U = ctx.Users.Find(ID);
            U.Password = Password;
            ctx.Users.Update(U);
            ctx.SaveChanges();
            return View("Show", U);
        }
        public IActionResult ShowCars()
        {
            if (HttpContext.Session.GetInt32("userid") == null)
                return View("Login");

            int? ID = HttpContext.Session.GetInt32("userid");
            User U = ctx.Users.Find(ID);
            List<Car> cars = ctx.Cars.Where(m => m.UserId == U.UserId).ToList();
            return View(cars);
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            int? ID = HttpContext.Session.GetInt32("userid");
            User U = ctx.Users.Find(ID);
            ViewBag.userid = U.UserId;
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(Car c)
        {
            ctx.Cars.Add(c);
            ctx.SaveChanges();
            
            
            return RedirectToAction("returnn", "Login");

        }
        [HttpGet]
        public IActionResult Delete(int CarId)
        {
            Car c = ctx.Cars.Find(CarId);
            if (c != null)
            {

                ctx.Cars.Remove(c);
                ctx.SaveChanges();
            }
            int? ID = HttpContext.Session.GetInt32("userid");
            User U = ctx.Users.Find(ID);

            List<Car> cars= ctx.Cars.Where(m => m.UserId == U.UserId ).ToList();

            return View("ShowCars",cars);
          
        }




    }






    }

