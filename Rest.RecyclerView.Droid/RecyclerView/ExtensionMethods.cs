using System;
using Android.Views;
using Recycler = Android.Support.V7.Widget.RecyclerView;

namespace Rest.RecyclerView.Droid.RecyclerViewListener
{
	public static class ExtensionMethods
	{
		public static void SetClickItemListener(this Recycler RecView, Action<Recycler, int, View> _Action)
		{
			RecView.AddOnChildAttachStateChangeListener(new AttachStateChangeListener(RecView, _Action));
		}
	}

	class AttachStateChangeListener : Java.Lang.Object,Recycler.IOnChildAttachStateChangeListener
	{
		Recycler _RecView;
		Action<Recycler, int, View> _Action;
		
		public AttachStateChangeListener(Recycler RecView, Action<Recycler, int, View> Action):base()
		{
			_RecView = RecView;
			_Action = Action;
		}

		public void OnChildViewAttachedToWindow(View view)
		{
			view.Click += ViewClick;
		}

		public void OnChildViewDetachedFromWindow(View view)
		{
			view.Click -= ViewClick;
		}

		void ViewClick(object sender, EventArgs e)
		{
			Recycler.ViewHolder ViewHolder = _RecView.GetChildViewHolder((View)sender);
			_Action.Invoke(_RecView, ViewHolder.AdapterPosition, (View)sender);
		}
}
}
