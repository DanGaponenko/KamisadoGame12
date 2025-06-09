using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;
using Android.Hardware.Lights;
//using AppLiorProject.Helper;
//using AppLiorProject.Model;
using static Android.Content.ClipData;
using KamisadoGame12.Helpers;
using AndroidX.AppCompat.View.Menu;

namespace KamisadoGame12.Activities
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity, View.IOnClickListener
    {
        string basesoldiercolor;
        string soldiercolor;
        Soldier current = new Soldier();
        string sl;//soldier color
        Color[,] bgcolors;
        Color[] clarr;
        string[] colors;
        Board board;
        LinearLayout Llmain;
        Button[,] btnGame;
        Game game;
        //Arr[,] d = new Arr[3, 3];
        LinearLayout.LayoutParams lp;
        LinearLayout llrow;
        TextView tvDisplay;
        Button btnReset;
        int gameSize;
        int counterClick = 0;
        int counter = 0;
        int position =0;
        //string cardcolor;
        int index = 0;
        string uid;
        FbData fbd;
        int score;
        string msgResult = string.Empty;
        int from = 0, to = 0;
        int secondpostion = 0;
        int right2 = 0;
        int legalright = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameLayout);
            //InitObject();
            InitGame();
            InitViews();
        }
        private void InitViews()
        {
            tvDisplay = FindViewById<TextView>(Resource.Id.tvDisplay);
            Llmain = FindViewById<LinearLayout>(Resource.Id.Llmain);
            btnGame = new Button[8, 8];
            View v = new View(this);
            LinearLayout.LayoutParams lp = new
            LinearLayout.LayoutParams
            (LinearLayout.LayoutParams.MatchParent, 100);
            v.LayoutParameters = lp;
            Llmain.AddView(v);
            LinearLayout.LayoutParams lp1 = new
            LinearLayout.LayoutParams
            (LinearLayout.LayoutParams.MatchParent,
            LinearLayout.LayoutParams.MatchParent);
            lp1.Weight = 1;
            for (int i = 0; i < 8; i++)
            {
                llrow = new LinearLayout(this);
                llrow.SetGravity(GravityFlags.Center);
                llrow.LayoutParameters = lp1;
                for (int j = 0; j < 8; j++)
                {
                    btnGame[i, j] = new Button(this);
                    btnGame[i, j].SetWidth(3);
                    btnGame[i, j].SetHeight(3);
                    btnGame[i, j].LayoutParameters = lp1;
                    btnGame[i, j].Tag = (string.Empty + i) + j;
                    string st = btnGame[i, j].Tag.ToString();
                    position = i * 10 + j;
                    btnGame[i, j].Text = (st);
                    Color c=bgcolors[i,j];
                    btnGame[i, j].SetBackgroundColor(c);
                    btnGame[i, j].SetTextColor(Color.Black);
                    if (i == 0)
                    {
                        current = game.BlackSoldier[j];
                        st = (game.BlackSoldier[j].Color);
                        btnGame[i, j].Text = (st);
                        btnGame[i,j].SetTextColor(Color.Black);
                    }
                    if (i == 7)
                    {
                        current = game.WhiteSoldier[j];
                        st = (game.WhiteSoldier[j].Color);
                        btnGame[i, j].Text = (st);
                        btnGame[i, j].SetTextColor(Color.White);
                    }
                    btnGame[i, j].TextSize = 10;
                    btnGame[i, j].SetOnClickListener(this);
                    llrow.AddView(btnGame[i, j]);
                }
                Llmain.AddView(llrow);
            }
            //Toast.MakeText(this, HelperGame.FindPostion(44, d),
            //ToastLength.Long).Show();
            tvDisplay.Text = "enjoy your game";
        }
        private void InitGame()
        {
            game = new Game();
            board = new Board();
            game.InitGame();
            board.InitBoard();
            bgcolors = new Color[8,8];
            //board.DoSomething();
            //Console.WriteLine(board.PostionAvailable());
            //tvDisplay.Text=board.Result.PrintBoard();
            clarr = new Color[8];
            colors = new string[8];
            SetColors (clarr);
            
        }

       

        private void SetColors(Color[] clarr)
        {
            clarr[0] = new Color(199, 104, 32); //orange
            clarr[1] = new Color(66, 136, 201);  //blue
            clarr[2] = new Color(92, 37, 107); //purple
            clarr[3] = new Color(194, 107, 168);  //pink
            clarr[4] = new Color(212, 196, 30);  //yellow
            clarr[5] = new Color(219, 61, 61);  //red
            clarr[6] = new Color(73, 125, 67);  //green
            clarr[7] = new Color(74, 40, 15);  //brown

            Toast.MakeText(this, board.ColorBoard[2, 3].Color, ToastLength.Short).Show();
            colors[0] = "orange";
            colors[1] = "blue";
            colors[2] = "purple";
            colors[3] = "pink";
            colors[4] = "yellow";
            colors[5] = "red";
            colors[6] = "green";
            colors[7] = "brown";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string clr = board.ColorBoard[i, j].Color;
                    int x = FindColor(clr);
                    bgcolors[i, j] = clarr[x];

                  //  bgcolors[i, j] = Color.Red;

                }
            }
        }

        private int FindColor(string clr)
        {
            for(int i = 0;i < 8; i++)
            {
                if (clr == colors[i]) return i;
            }
            return 0;
        }        

        //private void InitObject()
        //{
        //    HelperGame.GetExactPostion(d);
        //    //Toast.MakeText(this, HelperGame.FindPostion(44, d),
        //    ToastLength.Long).Show();
        //}
        //public void PutImage(int turn, Button b)
        //{
        //    if (turn % 2 == 0)
        //    {
        //        b.SetBackgroundResource(Resource.Drawable.Thebestx);
        //        //b.Clickable = false;
        //    }
        //    else
        //    {
        //        b.SetBackgroundResource(Resource.Drawable.ThebestO);
        //        //b.Clickable = false;
        //    }
        //}
        public void OnClick(View v)
        { 
            counterClick ++;
            Button b = (Button)v;
            position = int.Parse(b.Tag.ToString());
            if (counterClick % 2 != 0)
            {
                Button firstbtn = b;
            }
            else
            {
                Toast.MakeText(this, current.Color + " " + current.BaseColor, ToastLength.Short).Show();
                game.Step(position, current);
            }
            //int rt = HelperGame.FindPostion(right, d);
            //Toast.MakeText(this, b.Tag + "", ToastLength.Short).Show();
            //Toast.MakeText(this, position + "", ToastLength.Short).Show();
            //if (counter == 0)
            //{
            //    //right2 = HelperGame.Try1(right);//זה המקום הבא שמותר לי ללחוץ בו right 2
            //                                    //board.SetValueInPostion(left, rt);
            //    //board.SetValueInPostion(left, right2, counter);
            //    //PutImage(counter, b);
            //    counter++;
            //    //right2 = HelperGame.Try1(right);//זה המקום הבא שמותר לי ללחוץ בו right 2
            //    //legalright = HelperGame.Try1(right);
            //}
            //else
            //{
            //    //right2 = HelperGame.Try1(right);
            //    //board.DoSomething();
            //    //Toast.MakeText(this, board.Result.PrintBoard(), ToastLength.Short).Show();
            //    //if (board.Result.Checkall() == false)//כל עוד המשחק נמשך 
            //    //{

            //    //    //if (/*board.LegalPosition(right) && */HelperGame.IsExistInD(d, legalright, right))
            //    //    //if (right2 == left)
            //    //    {

            //    //        board.SetValueInPostion(left, right2, counter);
            //    //        //PutImage(counter, b);

            //    //        counter++;
            //    //        //legalright = HelperGame.Try1(right);
            //    //        Toast.MakeText(this, counter.ToString(), ToastLength.Short).Show();
            //    //    }
    

            //    //}
            //    //else
            //    //{
            //    //    tvDisplay.Text = board.Result.GetWinner().ToString();
            //    //    UpdateScore();
            //    //}
                

            //}
            

        }
        private void UpdateScore()
        {
            //Intent intent = new Intent(this, typeof
            //(UpdateScoreActivity));
            //intent.PutExtra("uid", uid);
            //StartActivity(intent);
        }

    }
}