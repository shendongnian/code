	public class MainViewModel : ViewModelBase
	{
		#region Background Color Flag
		private bool _Flag;
		public bool Flag
		{
			get { return this._Flag; }
			set
			{
				if (this._Flag != value)
				{
					this._Flag = value;
					RaisePropertyChanged(() => this.Flag);
				}
			}
		}
		#endregion Background Color Flag
		#region Button Command Handler
		private ICommand _ButtonCommand;
		public ICommand ButtonCommand
		{
			get { return this._ButtonCommand = (this._ButtonCommand ?? new RelayCommand(OnButtonPressed)); }
		}
		private void OnButtonPressed()
		{
			this.Flag = !this.Flag;
		}
		#endregion Button Command Handler
		public MainViewModel()
		{
		}
	}
