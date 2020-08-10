using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Minesweeper.Models
{
    public class Cell
    {
        //Getters and Setters functions.
        public int row { get; set; }
        public int column { get; set; }
        public bool visited { get; set; }
        public bool live { get; set; }

        public int liveNeighbors { get; set; }
        public bool hasFlag { get; set; }

        public Cell(int r, int c, bool v, bool b, int n, bool f)
        {
            //Variables
            row = r;
            column = c;
            visited = v;
            live = b;
            liveNeighbors = n;
            hasFlag = f;
        }
    }
}