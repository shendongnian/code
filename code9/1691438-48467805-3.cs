	public static class Extensions
	{
		public static IObservable<EventPattern<RoutedEventArgs>> ButtonClicks(this Button control)
		{
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
					h => control.Click += h,
					h => control.Click -= h);
		}
	}
