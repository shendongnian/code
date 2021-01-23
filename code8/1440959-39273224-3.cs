	public class AuxBindings : INotifyPropertyChanged
	{
		public AuxBindings()
		{
			ProgBarValue=0;
		}
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
		private int progBarValue;
		public int ProgBarValue
		{
			get
			{
				return progBarValue;
			}
			set
			{
				progBarValue = value;
				NotifyPropertyChanged();
			}
		}
	}
