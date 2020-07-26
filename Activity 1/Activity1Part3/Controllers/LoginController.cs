using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
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