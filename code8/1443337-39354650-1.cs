	public class ViewModel
	{
		public ViewModel()
		{
            //some dummy data
			Permissions.Add(new Permission()
			{
				Name = "Open",
				CanBeShow = true,
				Action = ApplicationCommands.Open
			});
			Permissions.Add(new Permission()
			{
				Name = "Save",
				CanBeShow = false,
				Action = ApplicationCommands.Save
			});
			Permissions.Add(new Permission()
			{
				Name = "Delete",
				CanBeShow = true,
				Action = ApplicationCommands.Delete
			});
		}
		public ObservableCollection<Permission> Permissions { get; } = new ObservableCollection<Permission>();
	}
	public class Permission:INotifyPropertyChanged
	{
		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
			}
		}
		private bool canBeShow;
		public bool CanBeShow
		{
			get { return canBeShow; }
			set
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CanBeShow)));
				canBeShow = value;
			}
		}
		private ICommand action;
		public ICommand Action
		{
			get { return action; }
			set {
				action = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Action)));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
