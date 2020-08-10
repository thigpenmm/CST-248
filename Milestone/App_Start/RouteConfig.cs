using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Minesweeper
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default map route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Map Route for Login page
            routes.MapRoute(
                name: "Login",
                url: "{Login}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            // Map route for register page
            routes.MapRoute(
                name: "Register",
                url: "{Register}",
                defaults: new { controller = "Register", action = "Register", id = UrlParameter.Optional }
            );

            // Map Route for Game Index page
            routes.MapRoute(
                name: "Game",
                url: "{game}",
                defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}