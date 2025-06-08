using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12
{
    public class Board
    {
        public Square[,] ColorBoard {  get; set; }


        public Board()
        {
            ColorBoard = new Square[8, 8];
        }

        public Board(Square[,] colorBoard)
        {
            ColorBoard = colorBoard;
        }

        public void InitBoard()//color sorting
        {
            Square sq;
            for (int i = 0; i < 8; i++)
            {
                sq = new Square("orange");
                ColorBoard[i, i] = sq;
            }
            for (int i = 0;i < 8; i++)
            {
                sq = new Square("brown");
                ColorBoard[i, 7 - i] = sq;
            }
            for (int i = 0; i < 4; i++)
            {
                sq = new Square("pink");
                ColorBoard[i, 3 - i] = sq;
                sq = new Square("yellow");
                ColorBoard[i, i + 4] = sq;
            }
            for (int i = 4;i < 8; i++)
            {
                sq = new Square("pink");
                ColorBoard[i, 11 - i] = sq;
                sq = new Square("yellow");
                ColorBoard[i, i - 4] = sq;
            }
            int b = 1, p = 2, r = 5 , g = 6;
            sq = new Square("blue");
            ColorBoard[0, b] = sq;
            sq = new Square("purple");
            ColorBoard[0, p] = sq;
            sq = new Square("red");
            ColorBoard[0, r] = sq;
            sq = new Square("green");
            ColorBoard[0, g] = sq;
            
            
            for (int i = 1; i < 8; i++)
            {
                b = (b + 3) % 8;
                p = (p + 5) % 8;
                r = (r + 3) % 8;
                g = (g + 5) % 8;
                sq = new Square("blue");
                ColorBoard[i, b] = sq;
                sq = new Square("purple");
                ColorBoard[i, p] = sq;
                sq = new Square("red");
                ColorBoard[i, r] = sq;
                sq = new Square("green");
                ColorBoard[i, g] = sq;
            }

            
        }
        public void PrintBoardColor()
        {
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.Write(ColorBoard[i, j].Color + " ");
                }
                Console.WriteLine();
            }
        }
        public void PrintBoardOccu()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(ColorBoard[i, j].IsOccupied + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
