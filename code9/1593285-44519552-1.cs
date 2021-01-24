    private bool isLoading;
		public bool IsLoading
		{
			get
			{
				return isLoading;
			}
			set
			{
				isLoading = value;
				RaisePropertyChanged("IsLoading");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
			}
		}
