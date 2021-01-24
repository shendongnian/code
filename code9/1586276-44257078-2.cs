	using System;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Controls.Primitives;
	using System.Windows.Input;
	namespace ShiftSlider
	{
		public partial class CustomSlider : UserControl
		{
			public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
				"Minimum", typeof(double), typeof(CustomSlider), new PropertyMetadata((double)0.0));
			public double Minimum
			{
				get { return (double) GetValue(MinimumProperty); }
				set { SetValue(MinimumProperty, value); }
			}
			public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
				"Maximum", typeof(double), typeof(CustomSlider), new PropertyMetadata((double)100.0));
			public double Maximum
			{
				get { return (double) GetValue(MaximumProperty); }
				set { SetValue(MaximumProperty, value); }
			}
			public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
				"Value", typeof(double), typeof(CustomSlider), new PropertyMetadata(default(double)));
			private double _lastPos;
			public double Value
			{
				get { return (double) GetValue(ValueProperty); }
				set { SetValue(ValueProperty, value); }
			}
			public CustomSlider()
			{
				InitializeComponent();
			}
			private void CMiXSlider_OnDragStarted(object sender, DragStartedEventArgs e)
			{
				e.Handled = true;
				_lastPos = GetMousePosition();
			}
			private double GetMousePosition()
			{
				return Mouse.GetPosition(this).X;
			}
			private void CMiXSlider_OnDragDelta(object sender, DragDeltaEventArgs e)
			{
				e.Handled = true;
				double thumbPosition = GetMousePosition();
				double deltaX = thumbPosition - _lastPos;
				_lastPos = thumbPosition;
				if (Keyboard.IsKeyDown(Key.LeftShift))
					deltaX /= 2;
				double effectiveLength = ActualWidth - CMiXSlider.ActualWidth;
				double effectiveChange = deltaX / effectiveLength;
				double valueRange = Maximum - Minimum;
				Value = Math.Min(Maximum, Math.Max(Minimum, Value + effectiveChange * valueRange));
				RepositionThumb();
			}
			private void RepositionThumb()
			{
				double relativePosition = (Value - Minimum) / (Maximum - Minimum);
				double absolutePosition = (ActualWidth - CMiXSlider.ActualWidth) * relativePosition;
				CMiXSlider.Margin = new Thickness(absolutePosition,0,0,0);
			}
			private void CMiXSlider_OnDragCompleted(object sender, DragCompletedEventArgs e)
			{
				// 
			}
		}
	}
