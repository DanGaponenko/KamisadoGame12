using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Firebase.Firestore.Model;
using KamisadoGame12.Helpers;
using KamisadoGame12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12.Activities
{
    [Activity(Label = "PlayerProfileActivity")]
    public class PlayerProfileActivity : Activity, IOnSuccessListener, IEventListener
    {
        EditText profileNameEt, profileScoreEt;
        Button profileUpdateBtn;
        FbData fbd;
        Player Player;

        string uid;
        public static string id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlayerProfileLayout);
            uid = Intent.GetStringExtra("uid");
            InitObjects();
            InitViews();
            GetProfileAsync();
            // Create your application here
        }

        private async void GetProfileAsync()
        {
            await fbd.GetCollection(General.FS_COLLECTION, uid).AddOnSuccessListener(this);
        }

        private void InitViews()
        {
            profileNameEt = FindViewById<EditText>(Resource.Id.profileNameEt);
            profileScoreEt = FindViewById<EditText>(Resource.Id.profileScoreEt);
            profileUpdateBtn = FindViewById<Button>(Resource.Id.profileUpdateBtn);
            profileUpdateBtn.Click += ProfileUpdateBtn_Click;
        }

        private async void ProfileUpdateBtn_Click(object sender, EventArgs e)
        {
            if (await UpdateData(profileNameEt.Text, profileScoreEt.Text))
            {
                Toast.MakeText(this, "updated", ToastLength.Short).Show(); 
            }
            else
            {
                Toast.MakeText(this, "update failed", ToastLength.Short).Show();
            }
        }

        private async Task<bool> UpdateData(string username, string score)
        {
            int scoreUpdate = int.Parse(score);
            try
            {
                DocumentReference PlayerReference = fbd.firestore.Collection(General.FS_COLLECTION).Document(uid);
                await PlayerReference.Update(General.KEY_USERNAME, username);
                await PlayerReference.Update(General.KEY_SCORE, score);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void InitObjects()
        {
            fbd = new FbData();
            Player = new Player();
            fbd.AddCollectionSnapShotListener(this, General.FS_COLLECTION);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            var snapshot = (DocumentSnapshot)result;
            //Id = id;
            //UserName = userName;
            //Mail = mail;
            //Password = password;
            //Score = score;
            Player = new Player(snapshot.Id, snapshot.Get("UserName").ToString(), snapshot.Get("Mail").ToString(), snapshot.Get("Password").ToString(), int.Parse(snapshot.Get("Score").ToString()));
            PrintUser(Player);
        }

        private void PrintUser(Player player)
        {
            profileNameEt.Text = player.UserName;
            profileScoreEt.Text = player.Score.ToString();
        }

        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException error)
        {
            //idk
        }
    }
}