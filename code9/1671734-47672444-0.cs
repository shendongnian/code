	public class SampleCommand<T> : ICommand where T : class 
	{
		/// <inheritdoc />
		public SampleCommand(Func<T, Task> execute)
		{
			this.execute = execute;
		}
		/// <inheritdoc />
		public bool CanExecute(object parameter)
		{
			return !isExecuting;
		}
		/// <inheritdoc />
		public async void Execute(object parameter)
		{
			await ExecuteAsync(parameter as T);
		}
		/// <inheritdoc />
		public event EventHandler CanExecuteChanged;
		private readonly Func<T, Task> execute;
		private bool isExecuting;
		public async Task ExecuteAsync(T parameter)
		{
			try
			{
				isExecuting = true;
				InvokeCanExecuteChanged();
				await execute(parameter);
			}
			finally
			{
				isExecuting = false;
				InvokeCanExecuteChanged();
			}
		}
		private void InvokeCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
	public class SampleViewModel
	{
		public SampleCommand<object> TaskedCommand { get; set; }
		public SampleViewModel()
		{
			TaskedCommand = new SampleCommand<object>(TaskExecutionAsync);
			RunSomeMoreInitialization();
			RunSomeMoreInitialization2();
		}
		private async void RunSomeMoreInitialization()
		{
			/*
			 * wpf usually calls it this way 
			 * if a user calls this he might not be aware of the different behavior of this void method 
			 */
			TaskedCommand.Execute(null);
			await Task.Delay(250);
			Debug.WriteLine("more code executed");
			/* 
			 * this will print 
			 * 
			 * more code executed
			 * command invoked
			 */
		}
		private async void RunSomeMoreInitialization2()
		{
			// user might manually call it this way.
			await TaskedCommand.ExecuteAsync(null);
			await Task.Delay(250);
			Debug.WriteLine("more code executed");
			/* 
			 * this will print 
			 * 
			 * command invoked
			 * more code executed
			 */
		}
		private Task TaskExecutionAsync(object o)
		{
			Task.Delay(500);
			Debug.WriteLine("command invoked");
			return Task.CompletedTask;
		}
	}
