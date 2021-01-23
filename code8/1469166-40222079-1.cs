	public enum States
	{
		State1,
		State2,
		State3,
		State4,
		State5,
	}
	public class StateImageConverter : IValueConverter
	{
		public ImageSource State1Image { get; set; }
		public ImageSource State2Image { get; set; }
		public ImageSource State3Image { get; set; }
		public ImageSource State4Image { get; set; }
		public ImageSource State5Image { get; set; }
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var state = value as States?;
			if(state.HasValue)
			{
				switch (state.Value)
				{
					case States.State1:
						return State1Image;
					case States.State2:
						return State2Image;
					case States.State3:
						return State3Image;
					case States.State4:
						return State4Image;
					case States.State5:
						return State5Image;
					default:
						throw new InvalidCastException();
				}
			}
			else
				throw new NotImplementedException();
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//one way only
			throw new NotImplementedException();
		}
	}
	public class VeiwModel : System.ComponentModel.INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private States state;
		public States State
		{
			get { return state; }
			set
			{
				state = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
			}
		}
		public IEnumerable<States> AllStates=> Enum.GetValues(typeof(States)).OfType< States>();
	}
