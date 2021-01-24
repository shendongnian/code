	public class CallbackCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;
		public bool CanExecute(object parameter)
			=> CanExecuteCallback?.Invoke(parameter) ?? true;
		public void Execute(object parameter)
			=> Callback(parameter);
		private Action<object> _Callback;
		public Action<object> Callback
		{
			get { return _Callback; }
			set
			{
				_Callback= value;
				CanExecuteChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		private Predicate<object> _CanExecuteCallback;
		public Predicate<object> CanExecuteCallback
		{
			get { return _CanExecuteCallback; }
			set
			{
				_CanExecuteCallback= value;
				CanExecuteChanged?.Invoke(this, EventArgs.Empty);
			}
		}
    }
