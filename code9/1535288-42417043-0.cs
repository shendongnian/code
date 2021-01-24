	public class MyVieWModel : INotifyPropertyChanged
	{
		private bool _cb1Checked;
		private bool _cb2Checked;
		public bool CB1Checked
		{
			get { return _cb1Checked; }
			set
			{
				_cb1Checked = value;
				PropertyChanged(this, new PropertyChangedEventArgs("CB1Checked"));
				PropertyChanged(this, new PropertyChangedEventArgs("CB3Checked"));
			}
		}
		public bool CB2Checked
		{
			get { return _cb2Checked; }
			set
			{
				_cb2Checked = value;
				PropertyChanged(this, new PropertyChangedEventArgs("CB2Checked"));
				PropertyChanged(this, new PropertyChangedEventArgs("CB3Checked"));
			}
		}
		public bool CB3Checked
		{
			get { return _cb1Checked && _cb2Checked; }
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
