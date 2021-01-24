        public class AwaitingCommand : ICommand
    	{
    		private bool _isBusy;
    
    		private Action<object> _callback;
    
    		/// <inheritdoc />
    		public AwaitingCommand(Action<object> callback)
    		{
    			_callback = callback;
    		}
    
    		/// <inheritdoc />
    		public bool CanExecute(object parameter)
    		{
    			return !_isBusy;
    		}
    
    		/// <inheritdoc />
    		public async void Execute(object parameter)
    		{
    			if (!_isBusy)
    			{
    				SetBusy(true);
    				await Task.Factory.StartNew(() => _callback?.Invoke(parameter), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    				SetBusy(false);
    			}
    		}
    
    		private void SetBusy(bool busy)
    		{
    			_isBusy = busy;
    			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    		}
    
    		/// <inheritdoc />
    		public event EventHandler CanExecuteChanged;
    	}
