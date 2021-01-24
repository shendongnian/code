	public class ViewModel : BindableBase
	{
		private Station _station;
		public Station Station
		{
			get => _station;
			set => SetProperty(ref _station, value);
		}
		private int _angleNegative;
		public int AngleNegative
		{
			get => _angleNegative;
			set => SetProperty(ref _angleNegative, value);
		}
		
		public ViewModel()
		{
			Station.PropertyChanged += Station_PropertyChanged;
		}
		
		private void Station_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Angle")
			{
				AngleNegative = Station.Angle - 180;
			}
		}
	}
