using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class Game
    {
        public Board board { get; set; }
        public int numberClick { get; set; }
        public int levelChoice { get; set; }

        public Cell row;
        public Cell column;
        public Game(Board board, int numberClick, int levelChoice)
        {
            this.board = board;
            this.numberClick = numberClick;
            this.levelChoice = levelChoice;
        }

        public Game()
        {
            this.board = new Board(8, 10);
            this.numberClick = 0;
            this.levelChoice = 10;
        }

        public void PlaceTurn(int row, int column)
        {

            if (board.isValidate(row, column) && board.theGrid[row, column].live == false)
            {

                //If a user avoids all mines
                if (this.board.theGrid[row, column].liveNeighbors == 0)
                {
                    board.floodFill(row, column);
                }
                if (checkWinCondition())
                {
                    Debug.WriteLine("You win");
                }
            }

            else if (board.isValidate(row, column) && this.board.theGrid[row, column].live == true)
            {
                //If a user clicks a mine
                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        board.theGrid[i, j].visited = true;
                    }
                }
                Debug.WriteLine("You lost");
            }
        }

        //Check if player has won.
        public bool checkWinCondition()
        {

            bool winCondition = true;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    //Player wins if not visisted cells are equal to mines remaining.
                    if (board.theGrid[i, j].visited == false && board.theGrid[i, j].live == false)
                    {
                        winCondition = false;
                    }
                }
            }
            return winCondition;
        }
    }
}