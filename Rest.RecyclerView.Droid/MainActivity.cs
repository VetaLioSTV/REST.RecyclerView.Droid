using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using ToolBar = Android.Support.V7.Widget.Toolbar;
using Recycler = Android.Support.V7.Widget.RecyclerView;
using System.Collections.Generic;
using System;
using Acr.UserDialogs;
using Android.Support.V7.Widget;
using System.Threading.Tasks;

namespace Rest.RecyclerView.Droid
{
	[Activity(Label = "Rest.RecyclerView.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{

		Recycler RecView;
		Recycler.LayoutManager RecManager;
		RecyclerViewAdapter Adapter;
		List<User> Lst;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			UserDialogs.Init(this);

			var _ToolBar = FindViewById<ToolBar>(Resource.Id.MainToolBar);
			SetSupportActionBar(_ToolBar);
			SupportActionBar.Title = "REST Implementation";

			RecView = FindViewById<Recycler>(Resource.Id.RecView);
			RecManager = new LinearLayoutManager(this);
			RecView.SetLayoutManager(RecManager);
			RecView.Visibility = Android.Views.ViewStates.Gone;

			var Btn = FindViewById<Button>(Resource.Id.Btn);

			Btn.Click += async (sender, e) =>
			{
				try
				{
					UserDialogs.Instance.Progress().PercentComplete = 50;
					Lst = await Client.GetRequestData<List<User>>();
					Adapter = new RecyclerViewAdapter(Lst);
					RecView.SetAdapter(Adapter);
					Btn.Visibility = Android.Views.ViewStates.Gone;
					RecView.Visibility = Android.Views.ViewStates.Visible;
					UserDialogs.Instance.Progress().Hide();
				}
				catch (System.Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			};
		}
	}
}

