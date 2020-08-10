using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class Board
    {
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public Cell[,] theGrid;


        //Sets the size of the gameboard.
        public Board(int s, int d)
        {
            Size = s;
            Difficulty = d;
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j, false, false, 0, false);
                }
            }
        }

        //Calculate and set each cell's neighbor values
        public void calcualateNeighbors()
        {
            foreach (Cell currentcell in theGrid)
            {
                if (currentcell.live == false)
                {
                    currentcell.liveNeighbors = 0;
                    for (int r = -1; r <= 1; r++)
                    {
                        for (int c = -1; c <= 1; c++)
                        {
                            if (isValidate(currentcell.row + r, currentcell.column + c) && theGrid[currentcell.row + r, currentcell.column + c].live == true)
                            {
                                currentcell.liveNeighbors++;
                            }
                        }
                    }
                    if (currentcell.live == true)
                    {
                        currentcell.liveNeighbors = 9;
                    }

                }
            }
        }

        //Determine the percentage of cells that will be set to live.
        public void activeSomeCellswithBombs()
        {
            Random rng = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {

                    if (rng.Next(100) < Difficulty)
                    {
                        theGrid[i, j].live = true;
                    }

                }
            }
        }

        //Check for out of bounds
        public bool isValidate(int r, int c)
        {
            return (r >= 0 && r < Size && c >= 0 && c < Size);
        }

        //Recursive search to see if cell has live neighbors and it isn't visited yet.
        public void floodFill(int x, int y)
        {
            theGrid[x, y].visited = true;

            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if (isValidate(x + r, y + c) && theGrid[x + r, y + c].visited == false && theGrid[x, y].liveNeighbors == 0)
                    {

                        floodFill(x + r, y + c);
                    }
                }
            }
        }
    }
}