using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12
{
    public class Game
    {
        public static bool turn = true; //white begins
        public static string lastcolor = string.Empty;//הצבע האחרון שדרכו עליו
        public Board GBoard { get; set; }
        public Soldier[] BlackSoldier { get; set; }//חיילים שחורים
        public Soldier[] WhiteSoldier { get; set; }//חיילים לבנים
        public string message { get; set; }

        public Game()//איתחולים
        {
            GBoard = new Board();
            BlackSoldier = new Soldier[8];
            WhiteSoldier = new Soldier[8];
            message = string.Empty;
        }

        public void InitGame()
        {
            this.GBoard.InitBoard();
            InitSoldiers();
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < BlackSoldier.Length; i++)
            {
                GBoard.ColorBoard[0,i].IsOccupied = true;
                GBoard.ColorBoard[7,i].IsOccupied = true;
            }
        }

        public void InitSoldiers()
        {
            Soldier sldr = new Soldier();
            string[] colors = new string[8]
            {
                "orange", "blue", "purple", "pink", "yellow", "red", "green", "brown"
            };
            for (int i = 0; i < this.BlackSoldier.Length; i++)
            {//מכניס את החיילים למקומות שלהם במערך
                sldr = new Soldier("black", colors[i], i, 0);
                this.BlackSoldier[i] = sldr;
                sldr = new Soldier("white", colors[7 - i], i, 7);
                this.WhiteSoldier[i] = sldr;
            }
        }
        public void PrintSoldiers()
        {
            for (int i = 0;i < WhiteSoldier.Length;i++)
            {
                Console.Write(WhiteSoldier[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < WhiteSoldier.Length;i++)
            {
                Console.Write(BlackSoldier[i] + " ");
            }
            Console.WriteLine();
        }
        //לכתוב פעולה הבודקת אם הצעד תקין
        //לכתוב פעולה הבודקת אם המשבצת תפוסה
        public string Step(int position , Soldier sldr)
        {
            int x, y;
            x = position/10;//row
            y = position%10;
            if (turn == true)//שחקן לבן
            {
                if (lastcolor  == string.Empty)//תור ראשון
                {
                    NextStep(position, sldr);
                }
                else//תור באמצע משחק
                {
                    if (sldr.Color == lastcolor)
                    {
                        NextStep(position, sldr);
                    }
                    else//שגיאה
                    {
                        message = "the turn is ilegal";
                    }
                }
                
                
            }
            else//שחקן שחור
            {
                if (sldr.Color == lastcolor)
                {
                    NextStep(position, sldr);
                }
                else//שגיאה
                {
                    message = "the turn is ilegal";
                }
            }
            return "idk";
        }
        public void NextStep(int position , Soldier sldr)
        {
            int x, y;
            x = position / 10;
            y = position % 10;
            GBoard.ColorBoard[sldr.SRow, sldr.SColumn].IsOccupied = false;
            sldr.SColumn = x;
            sldr.SRow = y;
            lastcolor = GBoard.ColorBoard[x, y].Color;
            GBoard.ColorBoard[x, y].IsOccupied = true;
            turn = !turn;
            //Console.WriteLine(sldr);
            //Console.WriteLine(lastcolor);
        }
        //public int SoldierPosition(Soldier sldr)
        //{
        //    if (sldr.BaseColor == "black")
        //    {
        //        for (int i = 0;i < WhiteSoldier.Length; i++)
        //        {
        //            if (sldr.Color == BlackSoldier[i].color)
        //            {

        //            }
        //        }
        //    }
        //}
        public int EndGame()
        {
            for (int i = 0; i < WhiteSoldier.Length; i++)
            {
                if(WhiteSoldier[i].SRow == 0)
                {
                    return 1;
                }
                if (BlackSoldier[i].SRow == 7)
                {
                    return 2;
                }
            }
            return -1;
        }
    }
}
