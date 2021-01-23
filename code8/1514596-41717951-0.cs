	public class PriorityConverter : IValueConverter
	{
		public Brush HighBrush { get; set; }
		public Brush LowBrush { get; set; }
		public Brush MediumBrush { get; set; }
		public Brush DefaultBrush { get; set; }
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var priority = value as Priority?;
			if (priority.HasValue)
			{
				switch (priority.Value)
				{
					case Priority.High:
						return HighBrush;
					case Priority.Medium:
						return MediumBrush;
					case Priority.Low:
						return LowBrush;
					default:
						return DefaultBrush;
				}
			}
			else
				throw new InvalidCastException($"{value} is not a Priority");
		}
