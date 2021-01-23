		protected override DependencyObject GetContainerForItemOverride()
		{
			return new MultiSelectTreeViewItem();
		}
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is MultiSelectTreeViewItem;
		}
