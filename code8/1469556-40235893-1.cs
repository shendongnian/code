	public interface ISavable
	{
		void Save();
		SaveCommand SaveCommand { get; }
	}
	public class SaveCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;
		public bool CanExecute(object parameter)
		{
			return parameter is ISavable;
		}
		public void Execute(object parameter)
		{
			Task.Run(()=>((ISavable)parameter).Save());
		}
	}
