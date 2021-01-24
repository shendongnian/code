	public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;
	
	public class SelectedItemEventArgs : EventArgs { }
	
	private void OnItemHasBeenSelected()
	{
		var handler = this.ItemHasBeenSelected;
		if (handler != null)
		{
			handler(this, new SelectedItemEventArgs());
		}
	}
