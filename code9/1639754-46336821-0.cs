	public DelegateCommand<ItemClickEventArgs> NavigateCommand { get; }
	private void OnMenuItemClicked(ItemClickEventArgs args)
	{
		HamburgerMenuPrismItem menuItem = (HamburgerMenuPrismItem)args.ClickedItem;
		_navigationService.Navigate(menuItem.TargetPageToken, null);
	}
