	public class ViewModel : INotifyPropertyChanged
	{
		public string TextBoxText => CheckBoxChecked ? "GOINTOTHEBOX!" : string.Empty;
		
		public bool CheckBoxChecked
		{
			get { return _checkBoxChecked; }
			set 
			{ 
				_checkBoxChecked = value; 
				OnPropertyChanged("CheckBoxChecked"); 
			}
		}
		
		private bool _checkBoxChecked;
	}
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
