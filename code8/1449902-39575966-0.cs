	using System.Collections.Generic;
	using System.Linq;
	using Android.App;
	using Android.OS;
	using SupportDialogFragment = Android.Support.V4.App.DialogFragment;
	namespace Example.Android.App.Views.Base
	{
		public class ListDialogFragment : SupportDialogFragment
		{
			public static readonly string TAG = "LIST_DIALOG";
			string _title;
			IList<string> _items;
			public static ListDialogFragment NewInstance(IList<string> items, string title)
			{
				ListDialogFragment frag = new ListDialogFragment();
				frag._items = items;
				frag._title = title;
				return frag;
			}
			public override Dialog OnCreateDialog(Bundle savedInstanceState)
			{
				AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
				builder.SetTitle(_title)
					   .SetItems(_items.ToArray(), (sender, e) => { /* implement your item click listener here */ })
					   .SetCancelable(true)
					   .SetNegativeButton("Cancel", (sender, e) => { /* implement your Cancel button click listener here */ });
				return builder.Create();
			}
		}
	}
