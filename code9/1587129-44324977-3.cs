    public ObservableCollection<int> Degrees = new ObservableCollection<int>
	{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
	};
	private int selectedDegrees = 0;
	public int SelectedDegrees
	{
		get { return selectedDegrees; }
		set { selectedDegrees = value; PropertyChanged?.Invoke(this, new ProportyChangedEventArgs(nameof(SelectedDegrees))); }
	}
	public ObservableCollection<int> Minutes = new ObservableCollection<int>
	{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
	};
	private int selectedMinutes = 0;
	public int SelectedMinutes
	{
		get { return selectedMinutes; }
		set { selectedMinutes = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMinutes))); }
	}
	public ObservableCollection<int> Seconds = new ObservableCollection<int>
	{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
	};
	private int selectedSeconds = 0;
	public int SelectedSeconds
	{
		get { return selectedSeconds; }
		set { selectedSeconds = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSeconds))); }
	}
	public ObservableCollection<int> Hundredth = new ObservableCollection<int>
	{
		0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
	};
	private int selectedHundredth = 0;
	public int SelectedHundredth
	{
		get { return selectedHundredth; }
		set { selectedHundredth = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedHundredth))); }
	}
    private async void Flyout_Opened(object sender, object e)
	{
		await Task.Delay(100);
		SelectedDegrees = 5;
		SelectedMinutes = 4;
		SelectedSeconds = 3;
		SelectedHundredth = 1;
	}
