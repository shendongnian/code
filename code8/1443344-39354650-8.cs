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
        //you will need to trigger the events when the permissions change
	}
