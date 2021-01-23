		using System;
		using Xamarin.Forms;
		using Xamarin.Forms.Platform.Android;
		using ListViewSample.Droid;
		[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellItemSelectedCustomRenderer))]
		namespace ListViewSample.Droid
		{
			public class ViewCellItemSelectedCustomRenderer : ViewCellRenderer
			{
				protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
				{
					var cell = base.GetCellCore(item, convertView, parent, context);
					cell.SetBackgroundResource(Resource.Drawable.ViewCellBackground);
					return cell;
				}
			}
		}
