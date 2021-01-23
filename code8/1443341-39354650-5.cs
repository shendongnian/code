	public class PermissionCommand:INotifyPropertyChanged,ICommand
	{
		public event EventHandler CanExecuteChanged;
		public event PropertyChangedEventHandler PropertyChanged;
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
			get
			{
				 //Check permissions for CanBeShow here 
			}
		}
		public bool CanExecute(object parameter)
		{
			//Check permissions for Execution here 
		}
		public void Execute(object parameter)
		{
			// perform action here
		}
	}
