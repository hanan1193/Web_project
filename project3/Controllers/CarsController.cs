using Microsoft.AspNetCore.Mvc;
using project3.Models;
namespace project3.Controllers

{
    public class CarsController : Controller
    {
        private DatasiteContext context { get; set; }

        public CarsController(DatasiteContext ctx) => context = ctx;
        public IActionResult CarsList()
        {
            List<Car> Cars = context.Cars.OrderBy(m => m.Type).ToList();
            return View(Cars);
        }
    }
}
