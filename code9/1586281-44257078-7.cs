	private void thumb_MouseEnter(object sender, MouseEventArgs e)
	{
		/*if (e.LeftButton == MouseButtonState.Pressed && e.MouseDevice.Captured == null)
		{
			MouseButtonEventArgs args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left);
			args.RoutedEvent = MouseLeftButtonDownEvent;
			(sender as Thumb).RaiseEvent(args);
		}*/
	}
	Point pStart;
	bool isDragging;
	private bool shiftDown;
	private double startValue;
	private void CMiXSlider_DragStarted(object sender, DragStartedEventArgs e)
	{
		isDragging = true;
		pStart = Mouse.GetPosition(CMiXSlider);
		shiftDown = Keyboard.IsKeyDown(Key.LeftShift);
		startValue = Value;
	}
	private void CMiXSlider_DragDelta(object sender, DragDeltaEventArgs e)
	{
		bool newShiftDown = Keyboard.IsKeyDown(Key.LeftShift);
		double scale = newShiftDown ? 0.5 : 1;
		Point pCurrent = Mouse.GetPosition(CMiXSlider);
		if (newShiftDown != shiftDown)
		{
			shiftDown = newShiftDown;
			pStart = pCurrent;
			startValue = Value;
		}
		Point pDelta = new Point(pCurrent.X - pStart.X, pCurrent.Y - pStart.Y);
		Value = startValue + (pDelta.X / CMiXSlider.ActualWidth) * scale;
		if (Value >= 1.0)
		{
			Value = 1.0;
		}
		else if (Value <= 0.0)
		{
			Value = 0.0;
		}
	}
	private void CMiXSlider_DragCompleted(object sender, DragCompletedEventArgs e)
	{
		isDragging = false;
	}
	private void CMiXSlider_KeyDown(object sender, KeyEventArgs e)
	{
		/*if (Keyboard.IsKeyDown(Key.LeftShift) && isDragging == true)
		{
			pStart = Mouse.GetPosition(CMiXSlider);
		}*/
	}
