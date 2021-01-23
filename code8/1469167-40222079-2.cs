	public class StateImageConverter : IValueConverter
	{
		public ObservableCollection<ImageSource> Images { get; set; } = new ObservableCollection<ImageSource>();
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var state = value as States?;
			if(state.HasValue)
			{
				return Images[(int)state.Value];
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
