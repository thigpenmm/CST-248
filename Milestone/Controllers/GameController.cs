
using Minesweeper.Models;
using System;
using System.Drawing;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        static Game game = new Game();

        Random random = new Random();

        public ActionResult Index()
        {
            return View("Menu");

        }

        // GET: Button
        public ActionResult Game()
        {
            game.board.activeSomeCellswithBombs();
            game.board.calcualateNeighbors();

            return View("Game", game);

        }

        public ActionResult HandleButtonClick(string mine)
        {

            String[] rc = mine.Split('|');
            Point p = new Point(Int32.Parse(rc[0]), Int32.Parse(rc[1]));

            game.board.theGrid[p.X, p.Y].visited = true;
            game.PlaceTurn(p.X, p.Y);

            return View("Game", game);

        }

        public ActionResult GameWon()
        {
            return View("GameWon");

        }
        public ActionResult GameLost()
        {
            return View("GameLost");

        }
    }
}