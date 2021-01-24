		public MyModel SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (_selectedItem != null)
					_selectedItem.Selected = false;
				_selectedItem = value;
				if (_selectedItem != null)
					_selectedItem.Selected = true;
			}
		}
