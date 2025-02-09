using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Util;
using KamisadoGame12.Helpers;
using KamisadoGame12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText RegisterPageUsernameEditText, RegisterPageEmailEditText, RegisterPagePasswordEditText;
        Button RegisterPageSubmitButton, RegisterPageTakePictureButton;
        FbData fbd;
        Player Player;
        string uid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Title = string.Empty;
            SetContentView(Resource.Layout.RegisterLayout);
            InitObject();
            InitViews();
        }

        private void InitObject()
        {
            fbd = new FbData();
            Player = new Player();
           
        }

        private void InitViews()
        {
            RegisterPageUsernameEditText = FindViewById<EditText>(Resource.Id.RegisterPageUsernameEditText);
            RegisterPageEmailEditText = FindViewById<EditText>(Resource.Id.RegisterPageEmailEditText);
            RegisterPagePasswordEditText = FindViewById<EditText>(Resource.Id.RegisterPagePasswordEditText);
            RegisterPageSubmitButton = FindViewById<Button>(Resource.Id.RegisterPageSubmitButton);
            RegisterPageSubmitButton.Click += RegisterPageSubmitButton_Click;
        }

        private async void RegisterPageSubmitButton_Click(object sender, EventArgs e)
        {
            if(await Register(RegisterPageUsernameEditText.Text, RegisterPageEmailEditText.Text, RegisterPagePasswordEditText.Text))
            {
                Toast.MakeText(this, "Registered successfully", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "register failed", ToastLength.Short).Show();
            }
        }

        private async Task<bool> Register(string userName, string mail, string password)
        {
            try
            {
                // Assuming fbd.auth is your Firebase auth object
                await fbd.auth.CreateUserWithEmailAndPassword(mail, password);

                HashMap userMap = new HashMap();
                userMap.Put(General.KEY_MAIL, mail);
                userMap.Put(General.KEY_USERNAME, userName);
                userMap.Put(General.KEY_PASSWORD, password);
                userMap.Put(General.KEY_ID, fbd.auth.CurrentUser.Uid);
                userMap.Put(General.KEY_SCORE, 0);

                DocumentReference userReference = fbd.firestore.Collection(General.FS_COLLECTION).Document(fbd.auth.CurrentUser.Uid);
                await userReference.Set(userMap);

                return true;  // Registration success
            }
            catch (Exception e)
            {
                // Log error or show detailed message
                Toast.MakeText(this, "Failed to register. Try again.", ToastLength.Short).Show();
                return false;
            }
        }
        

    }
}
    
