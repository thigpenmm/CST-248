using Activity2Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2Part1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<UserModel> userModels = new List<UserModel>();
            UserModel user1 = new UserModel("Bob", "test1@test.com", "(123)-456-7890");
            UserModel user2 = new UserModel("John", "test2@test.com", "(123)-182-0952");
            UserModel user3 = new UserModel("Dave", "test3@test.com", "(123)-923-0523");
            userModels.Add(user1);
            userModels.Add(user2);
            userModels.Add(user3);

            return View("Test", userModels);
        }
    }
}