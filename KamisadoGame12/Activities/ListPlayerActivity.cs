using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Google.Firestore.V1;
using KamisadoGame12.Helpers;
using KamisadoGame12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace KamisadoGame12.Activities
{
    [Activity(Label = "ListPlayerActivity")]
    public class ListPlayerActivity : Activity,IOnCompleteListener, IEventListener
    {

        ListView ListPlayerLv;
        List<Player> ListPlayer;
        PlayerAdapter pa;
        FbData fbd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListPlayerLayout);
            InitObject();
            InitViews();
            GetList();
        }

        private async void GetList()
        {
            Toast.MakeText(this, "getting list", ToastLength.Short).Show();
            await fbd.GetCollection(General.FS_COLLECTION).AddOnCompleteListener(this);
        }

        private void InitViews()
        {
            ListPlayerLv = FindViewById<ListView>(Resource.Id.ListPlayerLv);
            ListPlayerLv.ItemClick += ListPlayerLv_ItemClick;
            ListPlayerLv.ItemLongClick += ListPlayerLv_ItemLongClick;
        }

        private async void ListPlayerLv_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Player us = ListPlayer[e.Position];
            if (await DeleteUserAsync(us.Id))
            {
                Toast.MakeText(this, "deleted successfully", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "delete failed", ToastLength.Short).Show();
            }
        }

        private async Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                await fbd.DeleteFsDocument(General.FS_COLLECTION, id);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            return true;
        }

        private void ListPlayerLv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitObject()
        {
            fbd = new FbData();
            fbd.AddCollectionSnapShotListener(this, General.FS_COLLECTION);
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                ListPlayer = GetDocuments((QuerySnapshot)task.Result);
                if (ListPlayer.Count != 0)
                {
                    Toast.MakeText(this, "ok", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Empty", ToastLength.Short).Show();
                }

            }
        }

        private List<Player> GetDocuments(QuerySnapshot result)
        {
            ListPlayer = new List<Player>();
            foreach (DocumentSnapshot item in result.Documents)
            {
                Player player = new Player()
                {
                    UserName = item.Get(General.KEY_USERNAME).ToString(),
                    Score =int.Parse( item.Get(General.KEY_SCORE).ToString()),
                };
                ListPlayer.Add(player);
            }
            pa = new PlayerAdapter(this ,ListPlayer);
            ListPlayerLv.Adapter = pa;
            return ListPlayer;
        }

        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException error)
        {
            //idk
        }
    }
}