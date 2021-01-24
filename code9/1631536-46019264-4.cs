	public interface IAsyncCommand : ICommand
	{
		Task ExecuteAsync(object parameter);
	}
	public abstract class AsyncCommandBase : IAsyncCommand
	{
		public abstract bool CanExecute(object parameter);
		public abstract Task ExecuteAsync(object parameter);
		public async void Execute(object parameter)
		{
			await ExecuteAsync(parameter);
		}
        public event EventHandler CanExecuteChanged;
		
        protected void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
	public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
	{
		private readonly Func<Task<TResult>> _command;
		private NotifyTaskCompletion<TResult> _execution;
		public AsyncCommand(Func<Task<TResult>> command)
		{
			_command = command;
		}
		public override bool CanExecute(object parameter)
		{
			return Execution == null || Execution.IsCompleted;
		}
		public override async Task ExecuteAsync(object parameter)
		{
			Execution = new NotifyTaskCompletion<TResult>(_command());
			RaiseCanExecuteChanged();
			await Execution.TaskCompletion;
			RaiseCanExecuteChanged();
		}
		public NotifyTaskCompletion<TResult> Execution
		{
			get { return _execution; }
			private set
			{
				_execution = value;
				OnPropertyChanged();
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
