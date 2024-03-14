using Microsoft.AspNetCore.Mvc;
using project3.Models;
using System.Xml.Linq;
namespace project3.Controllers
{
    public class LoginController : Controller

    {
        public DatasiteContext ctx { get; set; }
        public LoginController(DatasiteContext ctx) { this.ctx = ctx; }
        
        [HttpGet]
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Login(User s)
        {
           

            User mv = ctx.Users.Where(m => (m.Name == s.Name && m.Password == s.Password)).FirstOrDefault();
            if (mv != null)
            {
                HttpContext.Session.SetInt32("userid", mv.UserId);
                return View("UserBage",mv);
            }
            else
                return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult returnn()
        {
            int? ID = HttpContext.Session.GetInt32("userid");
            User U = ctx.Users.Find(ID);
            return View("UserBage",U);
        }


    }
  
}

