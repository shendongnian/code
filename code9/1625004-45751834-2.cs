    public class Authority : INotifyPropertyChanged
    {
        private string authorityName;
        private int authorityValue;
        private bool isChecked;
        public string AuthorityName
		{
			get { return authorityName; }
			set
			{
				authorityName = value;
				NotifyPropertyChanged();
			}
		}
		public int AuthorityValue
		{
			get { return authorityValue; }
			set
			{
				authorityValue = value;
				NotifyPropertyChanged();
			}
		}
		public bool IsChecked
		{
			get { return isChecked; }
			set
			{
				isChecked = value;
				NotifyPropertyChanged();
			}
		}
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
