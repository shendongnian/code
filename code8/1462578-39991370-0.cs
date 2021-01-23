    public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChangedEvent(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
    // This sample class DelegateCommand is used if you wanna bind an event action with your view model
	public class DelegateCommand : ICommand
	{
		private readonly Action _action;
		public DelegateCommand(Action action)
		{
			_action = action;
		}
		public void Execute(object parameter)
		{
			_action();
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}
	#pragma warning disable 67
		public event EventHandler CanExecuteChanged;
	#pragma warning restore 67
	}
