using Activity2Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2Part1.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons;
        // GET: Button
        public ActionResult Index()
        {
            buttons = new List<ButtonModel>() { new ButtonModel(true), new ButtonModel(false) };
            return View("Button", buttons);
        }

        public ActionResult OnButtonClick(string mine) 
        {
            if (mine == "1")
            {
                buttons[0].State = !buttons[0].State;
            }
            if (mine == "2")
            {
                buttons[1].State = !buttons[1].State;
            }
            return View("Button", buttons);
        }
    }
}