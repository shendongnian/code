		private void TimelineCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			Point relativePosition = e.GetPosition(timelineOuterBox);
			double selectionWidth = (relativePosition.X / timelineOuterBox.Width) * timelineOuterBox.Width;
			timelineSelectionBox.Width = selectionWidth.Clamp(0.0, timelineOuterBox.Width);
			if (isDraggingThumb)
			{
				timelineProgressBox.Width = timelineSelectionBox.Width;
				//Thickness thumbMargin = new Thickness(TimelineThickness * TimelineExpansionFactor,
				//	(timelineCanvas.RenderSize.Height - (TimelineThickness * TimelineExpansionFactor)) / 2, 0, 0);
				//timelineThumb.Margin = thumbMargin;
			    Canvas.SetLeft(timelineThumb, timelineProgressBox.Width);
			}
		}
		private bool isDraggingThumb = false;		
        
        private void TimelineThumb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		    e.Handled = true;
			//CaptureMouse();
			isDraggingThumb = true;
			Trace.WriteLine("Dragging Thumb");
		}
		private void TimelineThumb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
		    e.Handled = true;
            //ReleaseMouseCapture();
            isDraggingThumb = false;
			Trace.WriteLine("STOPPED Dragging Thumb");
		}
