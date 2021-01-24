	using System;
	using System.Windows.Controls;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Reactive.Linq;
	using System.Threading;
	namespace SmoothOutButtonTapping
	{
		public partial class SmoothTapButtonControl : UserControl
		{
			public SmoothTapButtonControl()
			{
				InitializeComponent();
				_pressed = new SolidColorBrush(Colors.Lime);
				_released = Background;
				
				//	Don't forget to call ObserveOn() to ensure your UI controls
                //  only get accessed from the UI thread.
				Filters.FilterMouseStream(button, SlidingTimeoutWindow)
					.ObserveOn(SynchronizationContext.Current)
					.Subscribe(HandleClicked);
			}
			//	This property indicates how long the button must wait before 
            //  responding to being released.
			//	If the button is pressed again before this timeout window 
            //  expires, it resets.
			//	This is handled for us automatically by Reactive Extensions.
			public TimeSpan SlidingTimeoutWindow { get; set; } = TimeSpan.FromSeconds(.4);
			private void HandleClicked(MouseButtonState state)
			{
				if (state == MouseButtonState.Pressed)
					Background = _pressed;
				else
					Background = _released;
			}
			private Brush _pressed;
			private Brush _released;
		}
	}
