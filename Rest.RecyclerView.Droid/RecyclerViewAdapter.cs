﻿using System;
using Android.Support.V7.Widget;
using Android.Views;
using Recycler = Android.Support.V7.Widget.RecyclerView;
using Android.Widget;
using System.Collections.Generic;

namespace Rest.RecyclerView.Droid
{
	public class RecyclerViewAdapter : Recycler.Adapter
	{
		List<User> SourceList;
		public RecyclerViewAdapter(List<User> Source)
		{
			SourceList = Source;
		}

		public override int ItemCount
		{
			get
			{
				return SourceList.Count;
			}
		}

		public override void OnBindViewHolder(Recycler.ViewHolder holder, int position)
		{
			var ViewHolder = (RecyclerViewHolder)holder;

			ViewHolder.Address.Text = SourceList[position].address.street;
			ViewHolder.Company.Text = SourceList[position].company.name;
			ViewHolder.ID.Text = SourceList[position].id.ToString();
		}

		public override Recycler.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var View = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.CardViewItem, parent, false);
			return new RecyclerViewHolder(View);
		}
	}


	class RecyclerViewHolder : Recycler.ViewHolder
	{
		public TextView Address { get; set; }

		public TextView ID { get; set; }

		public TextView Company { get; set; }

		public RecyclerViewHolder(View RecyclerItemView) : base(RecyclerItemView)
		{
			Address = RecyclerItemView.FindViewById<TextView>(Resource.Id.Address);
			ID = RecyclerItemView.FindViewById<TextView>(Resource.Id.ID);
			Company = RecyclerItemView.FindViewById<TextView>(Resource.Id.Company);
		}
	}
}