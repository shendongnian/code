	public class AuxBindings : INotifyPropertyChanged
	{
		public AuxBindings()
		{
			ProgBarValue=0;
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
