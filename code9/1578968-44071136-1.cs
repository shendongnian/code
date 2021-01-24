		/// <summary>
		/// Invoked when an unhandled MouseLeftButtonUp routed event reaches an element in 
		/// its route that is derived from this class. Implement this method to add class 
		/// handling for this event.
		/// </summary>
		/// <param name="e">The MouseButtonEventArgs that contains the event data. The event 
		/// data reports that the left mouse button was released.</param>
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
		    isDraggingThumb = false;
