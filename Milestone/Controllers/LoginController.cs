using Minesweeper.Models;
using Minesweeper.Services.Business;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            SecurityService authService = new SecurityService();

            bool authorized = authService.Authenticate(model);

            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            if (authorized)
            {
                return View("LoginPassed", model);
            }
            else
            {
                return View("LoginFailed");
            }
        }
    }
}