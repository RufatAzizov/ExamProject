using Exam.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Areas.Admin.Controllers
{
    public class FruitsController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
