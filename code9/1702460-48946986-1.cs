	internal class MyGestureListener : GestureDetector.SimpleOnGestureListener
	{
		public FrameWithLongTouchGesture MyFrame { private get; set; }
		
		public override void OnLongPress(MotionEvent e)
		{
			base.OnLongPress(e);
			
			if (MyFrame != null)
			{
				MyFrame.HandleLongPress(this, new System.EventArgs());
			}
		}
	}
