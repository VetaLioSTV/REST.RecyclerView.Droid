
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBar = Android.Support.V7.Widget.Toolbar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Rest.RecyclerView.Droid
{
	[Activity(Label = "SecondActivity")]
	public class SecondActivity : AppCompatActivity
	{
		ToolBar _ToolBar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Second);

			_ToolBar = FindViewById<ToolBar>(Resource.Id.ToolBar);
			var Street = FindViewById<TextView>(Resource.Id.Street).Text = $"Street adress : {Intent.GetStringExtra("Street")}";
			var ZipCode = FindViewById<TextView>(Resource.Id.ZipCode).Text = $"ZipCode : {Intent.GetStringExtra("ZipCode")}";
			var Suite = FindViewById<TextView>(Resource.Id.Suite).Text = $"Suite - {Intent.GetStringExtra("Title")}";
			var City = FindViewById<TextView>(Resource.Id.City).Text = $"City is {Intent.GetStringExtra("City")}";
			SetSupportActionBar(_ToolBar);
			SupportActionBar.Title = Intent.GetStringExtra("Title");

			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					Finish();
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}
	}
}
