using Android.App;
using Android.Content;
using Android.Gms.Extensions;

//using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KamisadoGame12.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        EditText etMail, etPass;
        TextView tvDisplay;
        Button btnLogin;
        FbData fbd;
       // UserServices us;
      // List<UserProject> list;

        string uid;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);
            initviews();
            Initobject();
        }
        private void Initobject()
        {
            //us = new UserServices();
            //list = us.usersList;
            fbd = new FbData();
        }

        private void initviews()
        {
            etMail = FindViewById<EditText>(Resource.Id.etMail);
            etPass = FindViewById<EditText>(Resource.Id.etPassword);
            tvDisplay = FindViewById<TextView>(Resource.Id.tvDisplay);
            btnLogin = FindViewById<Button>(Resource.Id.btnSubmit);
            btnLogin.Click += BtnLogin_Click;
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            //tvDisplay.Text = etMail.Text + " " + etPass.Text;
            if (await LoginUser(etMail.Text, etPass.Text))
            {
                Toast.MakeText(this, "logged in successfully", ToastLength.Short).Show();
                etMail.Text = "";
                etPass.Text = "";
                Intent intent = new Intent(this, typeof(PlayerProfileActivity));
                intent.PutExtra("uid", uid);
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "login failed :(", ToastLength.Short);
            }
        }
        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await fbd.auth.SignInWithEmailAndPassword(email, password);
                uid = fbd.auth.CurrentUser.Uid;
            }
            catch (System.Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            return true;
        }
    }
}