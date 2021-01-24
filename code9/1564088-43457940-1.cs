    public class CheckListGeneric: ViewModelBase
	{
		#region ..:: Fields ::..
		private bool _isChecked;
		#endregion
		#region ..:: Properties ::..
		public long Id { get; set; }
		public string DescCompuesta{ get; set; }
		public bool IsChecked
		{
			get { return _isChecked; }
			set { _isChecked = value; OnPropertyChanged("IsChecked"); }
		}
		#endregion
	}
