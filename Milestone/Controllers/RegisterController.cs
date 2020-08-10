using Minesweeper.Models;
using Minesweeper.Services.Business;
using System.Web.Mvc;

namespace Minesweeper.Controllers

{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            SecurityService service = new SecurityService();

            bool result = service.register(model);

            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            if (result)
            {
                return View("RegisterPassed", model);
            }
            else
            {
                return View("RegisterFailed");
            }
        }
    }
}