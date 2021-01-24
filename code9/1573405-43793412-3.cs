	using System.Linq;
	using Windows.UI.Xaml.Controls;
	public class ChatListView : ListView
	{
		protected override void OnItemsChanged(object e)
		{
			base.OnItemsChanged(e);
			if(Items.Count > 0) ScrollIntoView(Items.Last());
		}
	}
