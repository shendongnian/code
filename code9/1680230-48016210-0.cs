	private DateTime? _selectedDate;
	public DateTime? SelectedDate
	{
		get { return _selectedDate == DateTime.Parse("01.01.0001") ? null : _selectedDate; }
		set
		{
			if (_selectedDate != value)
			{
				_selectedDate = value;
				NotifyPropertyChanged();
			}
		}
	}
