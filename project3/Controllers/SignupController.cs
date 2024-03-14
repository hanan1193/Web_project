using Microsoft.AspNetCore.Mvc;
using project3.Models;

namespace project3.Controllers

{
    public class SignupController : Controller
    {
        public DatasiteContext ctx { get; set; }
        public SignupController(DatasiteContext ctx) { this.ctx = ctx; }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User mv)
        {
            ctx.Users.Add(mv);
            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
            
        }
    }
}
