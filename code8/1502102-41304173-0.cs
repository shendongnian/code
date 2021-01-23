	class MyWnd : Window
	{		
		public MyWnd()
		{
			var c = new Canvas();
			c.Background = new SolidColorBrush(Colors.White);
	
			var rect = new Rectangle { Fill = new SolidColorBrush(Colors.Red), Width = 20, Height = 20 };
			c.Children.Add(rect);
	
			this.Content = c;
	
			Canvas.SetLeft(rect, 0);
			Canvas.SetTop(rect, 0);
			
			rect.MouseLeftButtonDown+=Handle_MouseDown;
			rect.MouseLeftButtonUp+=Handle_MouseUp;
			rect.MouseMove+=Handle_MouseMove;
		}
	
	
		bool isMouseCaptured;
		double mouseVerticalPosition;
		double mouseHorizontalPosition;
	
		public void Handle_MouseDown(object sender, MouseEventArgs args)
		{
			var item = sender as FrameworkElement;
			mouseVerticalPosition = args.GetPosition(null).Y;
			mouseHorizontalPosition = args.GetPosition(null).X;
			isMouseCaptured = true;
			item.CaptureMouse();
		}
	
		public void Handle_MouseMove(object sender, MouseEventArgs args)
		{
			var item = sender as FrameworkElement;
			if (isMouseCaptured)
			{
	
				// Calculate the current position of the object.
				double deltaV = args.GetPosition(null).Y - mouseVerticalPosition;
				double deltaH = args.GetPosition(null).X - mouseHorizontalPosition;
				double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
				double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);
	
				// Set new position of object.
				item.SetValue(Canvas.TopProperty, newTop);
				item.SetValue(Canvas.LeftProperty, newLeft);
	
				// Update position global variables.
				mouseVerticalPosition = args.GetPosition(null).Y;
				mouseHorizontalPosition = args.GetPosition(null).X;
			}
		}
	
		public void Handle_MouseUp(object sender, MouseEventArgs args)
		{
			var item = sender as FrameworkElement;
			isMouseCaptured = false;
			item.ReleaseMouseCapture();
			mouseVerticalPosition = -1;
			mouseHorizontalPosition = -1;
		}
	}
	
	void Main()
	{
		var wnd = new MyWnd();
		wnd.ShowDialog();
	}
