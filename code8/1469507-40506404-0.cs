	internal class MyViewModel : BindableBase, INavigationAware
	{
		public MyViewModel( IDataSource theSourceOfData )
		{
			_theSourceOfData = theSourceOfData;
			UpdateCommand = new DelegateCommand( UpdateData );
		}
		public string MyProperty
		{
			get
			{
				return _myProperty;
			}
			set
			{
				SetProperty( ref _myProperty, value );
			}
		}
		public DelegateCommand UpdateCommand { get; }
		#region INavigationAware
		public void OnNavigatedTo( NavigationContext navigationContext )
		{
			UpdateData();
		}
		#endregion
		#region private
		private readonly IDataSource _theSourceOfData;
		private string _myProperty;
		private void UpdateData()
		{
			_myProperty = _theSourceOfData.FetchTheData();
		}
		#endregion
	}
