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

namespace KamisadoGame12.Activities
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity, View.IOnClickListener
    {
        //MasterBoard board;
        LinearLayout Llmain;
        Button[,] btnGame;
        //GameLogic game;
        //Arr[,] d = new Arr[3, 3];
        LinearLayout.LayoutParams lp;
        LinearLayout llrow;
        TextView tvDisplay;
        Button btnReset;
        int gameSize;
        int counter = 0;
        int position;
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
            //InitGame();
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
                    //int pos = HelperGame.FindPostion(i * 10 + j, d);
                    //st = pos.ToString() + st;
                    btnGame[i, j].Text = (st);
                    //btnGame[i, j].SetBackgroundResource
                    //(Resource.Drawable.BackviewUnoCard);
                    btnGame[i, j].SetTextColor(Color.Red);
                    btnGame[i, j].TextSize = 10;
                    //btnGame[i, j].SetOnClickListener(this);
                    llrow.AddView(btnGame[i, j]);
                }
                Llmain.AddView(llrow);
            }
            //Toast.MakeText(this, HelperGame.FindPostion(44, d),
            //ToastLength.Long).Show();
            tvDisplay.Text = "enjoy your game";
        }
        //private void InitGame()
        //{
        //    board = new MasterBoard();
        //    board.InitMasterBoard();
        //    board.DoSomething();
        //    //Console.WriteLine(board.PostionAvailable());
        //    //tvDisplay.Text=board.Result.PrintBoard();
        //}
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

            Button b = (Button)v;
            int position = int.Parse(b.Text);
            int left = position / 100;// המיקום היחסי הכללי כיאילו
            int right = position % 100;//זה המיקום האמיתי
            //int rt = HelperGame.FindPostion(right, d);

            if (counter == 0)
            {
                //right2 = HelperGame.Try1(right);//זה המקום הבא שמותר לי ללחוץ בו right 2
                                                //board.SetValueInPostion(left, rt);
                //board.SetValueInPostion(left, right2, counter);
                //PutImage(counter, b);
                counter++;
                //right2 = HelperGame.Try1(right);//זה המקום הבא שמותר לי ללחוץ בו right 2
                //legalright = HelperGame.Try1(right);
            }
            else
            {
                //right2 = HelperGame.Try1(right);
                //board.DoSomething();
                //Toast.MakeText(this, board.Result.PrintBoard(), ToastLength.Short).Show();
                //if (board.Result.Checkall() == false)//כל עוד המשחק נמשך 
                //{

                //    //if (/*board.LegalPosition(right) && */HelperGame.IsExistInD(d, legalright, right))
                //    //if (right2 == left)
                //    {

                //        board.SetValueInPostion(left, right2, counter);
                //        //PutImage(counter, b);

                //        counter++;
                //        //legalright = HelperGame.Try1(right);
                //        Toast.MakeText(this, counter.ToString(), ToastLength.Short).Show();
                //    }
    

                //}
                //else
                //{
                //    tvDisplay.Text = board.Result.GetWinner().ToString();
                //    UpdateScore();
                //}
                

            }
            

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