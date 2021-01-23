	internal class MyViewModel : INotifyPropertyChanged
	{
		public MyViewModel( IServer server )
		{
			MyCommand = new DelegateCommand( async () => MyProperty = await server.GetNewData() );
		}
		#region Bindings
		public string MyProperty
		{
			get
			{
				return _myProperty;
			}
			set
			{
				_myProperty = value;
				OnPropertyChanged();
			}
		}
		public ICommand MyCommand { get; }
		#endregion
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		#region private
		private string _myProperty;
		private void OnPropertyChanged( [CallerMemberName] string propertyName = null )
		{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}
		#endregion
	}
	public interface IServer
	{
		Task<string> GetNewData();
	}
