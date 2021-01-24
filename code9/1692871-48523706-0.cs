    public class MultiBoolToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
			if(values.All(v=>v is bool))
				return values.All(v=>(bool)v)?
					Visibility.Visible:
					Visibility.Hidden;
			else
				throw new ArgumentException("Cannot determine boolean state of non-boolean value");
        }
    }
