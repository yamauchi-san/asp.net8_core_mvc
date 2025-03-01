using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class ErrorDetailController : Controller
    {
        public IActionResult NotFoundPage(string message)
        {
            ViewData["ErrorMessage"] = message;
            return View();
        }
    }
}
