	using System;
	using System.Windows.Controls;
	using System.Windows.Input;
	using System.Linq;
	using System.Reactive.Linq;
	namespace SmoothOutButtonTapping
	{
		public static class Filters
		{
			//	First we need to combine the pressed events and the released
			//	events into a single unfiltered stream.
			private static IObservable<MouseButtonState> GetUnfilteredStream(Button button)
			{
				var pressedUnfiltered = Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
					x => button.PreviewMouseLeftButtonDown += x,
					x => button.PreviewMouseLeftButtonDown -= x);
				var releasedUnfiltered = Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
					x => button.PreviewMouseLeftButtonUp += x,
					x => button.PreviewMouseLeftButtonUp -= x);
				return pressedUnfiltered
					.Merge(releasedUnfiltered)
					.Select(x => x.EventArgs.ButtonState);
			}
			//	Now we need to apply some filters to the stream of events.
			public static IObservable<MouseButtonState> FilterMouseStream(
				Button button, TimeSpan slidingTimeoutWindow)
			{
				var unfiltered = GetUnfilteredStream(button);
				//	Ironically, we have to separate the pressed and released events, even
				//	though we just combined them. 
				//	This is because we need to apply a filter to throttle the released events,
				//	but we don't need to apply any filters to the pressed events.
				var released = unfiltered
					
					//	Here we throttle the events so that we don't get a released event
					//	unless the button has been released for a bit.
					.Throttle(slidingTimeoutWindow)
					.Where(x => x == MouseButtonState.Released);
				
				var pressed = unfiltered
					.Where(x => x == MouseButtonState.Pressed);
				//	Now we combine the throttled stream of released events with the unmodified
				//	stream of pressed events.
				return released.Merge(pressed);
			}
		}
	}
