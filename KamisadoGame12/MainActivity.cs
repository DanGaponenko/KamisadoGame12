using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using KamisadoGame12.Activities;
using System;

namespace KamisadoGame12
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //idk
        Button btnMainRegister, btnMainLogin, btnMainList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            InitViews();
        }

        private void InitViews()
        {
            btnMainList = FindViewById<Button>(Resource.Id.btnMainList);
            btnMainList.Click += BtnMainList_Click;
            btnMainLogin = FindViewById<Button>(Resource.Id.btnMainLogin);
            btnMainLogin.Click += BtnMainLogin_Click;
            btnMainRegister = FindViewById<Button>(Resource.Id.btnMainRegister);
            btnMainRegister.Click += BtnMainRegister_Click;
        }

        private void BtnMainRegister_Click(object sender, EventArgs e)
        {
            Intent intent=new Intent(this,typeof(RegisterActivity));
            StartActivity   (intent);
        }

        private void BtnMainLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity (intent);
        }

        private void BtnMainList_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ListPlayerActivity));
            StartActivity (intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}