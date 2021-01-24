	private void OnItemHasBeenSelected()
	{
		if (this.ItemHasBeenSelected != null)
		{
			this.ItemHasBeenSelected(this, new SelectedItemEventArgs());
		}
	}
