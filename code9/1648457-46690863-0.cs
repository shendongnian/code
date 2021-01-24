	namespace Foo.Converters {
		public class TimespanConverter : IValueConverter {
			public static Func<double, TimeSpan> FromMilliseconds => TimeSpan.FromMilliseconds;
			public static Func<double, TimeSpan> FromSeconds => TimeSpan.FromSeconds;
			public static Func<double, TimeSpan> FromMinutes => TimeSpan.FromMinutes;
			public static Func<double, TimeSpan> FromHours => TimeSpan.FromHours;
			public static Func<double, TimeSpan> FromDays => TimeSpan.FromDays;
			public object Convert(
				object value, Type targetType, object parameter, CultureInfo culture ) =>
				( parameter as Func<double, TimeSpan> )?.Invoke( ( double )( value ) );
			public object ConvertBack(
				object value, Type targetType, object parameter, CultureInfo culture ) =>
				throw new NotImplementedException( );
		}
	}
