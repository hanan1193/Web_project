using Microsoft.AspNetCore.Mvc;
using project3.Models;

namespace project3.Controllers
{
    public class SearchController : Controller
    {
        public DatasiteContext ctx { get; set; }
        public SearchController(DatasiteContext ctx) { this.ctx = ctx; }
        [HttpPost]
        public IActionResult Index(string Type, int Model , string Color , double Price)
        {
            List<Car> Cars = ctx.Cars.Where(m => m.Type == Type || m.Model == Model || m.Color == Color || m.Price == Price).ToList();
            return View(Cars);
        }
    }
}
