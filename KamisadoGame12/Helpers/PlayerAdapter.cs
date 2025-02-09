using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KamisadoGame12.Activities;
using KamisadoGame12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Gms.Common.Apis.Api;

namespace KamisadoGame12.Helpers
{
    internal class PlayerAdapter : BaseAdapter<Player>
    {

        Context context;
        private List<Player> listplayer;

        public PlayerAdapter(Context context)
        {
            this.context = context;
        }

        public PlayerAdapter(Context context, List<Player> listplayer)
        {
            this.listplayer = listplayer;
            this.context = context;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layoutInflater;
            layoutInflater = ((ListPlayerActivity)context).LayoutInflater;
            View view = layoutInflater.Inflate(Resource.Layout.ListPlayerRowLayout, parent, false);
            TextView UserListRowUsername = view.FindViewById<TextView>(Resource.Id.UserListRowUsernameTextView);
            TextView UserListRowScore = view.FindViewById<TextView>(Resource.Id.UserListRowScoreTextView);
      
            Player player = listplayer[position];
            if (player != null)
            {
                UserListRowUsername.Text = UserListRowUsername.Text + player.UserName;
                UserListRowScore.Text = UserListRowScore.Text + player.Score.ToString();


            }

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return listplayer.Count;
            }
        }

        public override Player this[int position]
        {
            get
            {
                return listplayer[position];    
            }
        }
    }

    internal class PlayerAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}