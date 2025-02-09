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

namespace KamisadoGame12.Model
{
    public class Player
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }

        public Player(string id, string userName, string mail, string password, int score)
        {
            Id = id;
            UserName = userName;
            Mail = mail;
            Password = password;
            Score = score;
        }

        public Player()
        {
            Id = string.Empty;
            UserName = string.Empty;
            Mail = string.Empty;
            Password = string.Empty;
            Score = 0;
        }
    }
}