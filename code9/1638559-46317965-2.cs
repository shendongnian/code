    class ContextMenuItemVM
	{
		
		public string Name { get; }
		public bool IsCheckable { get; }
		public bool IsChecked { get; set; }
		public ICommand Cmd { get; }
	}
