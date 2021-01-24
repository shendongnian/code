	public class FrameWithLongTouchGestureRenderer : FrameRenderer
	{
		FrameWithLongTouchGesture view;
		readonly MyGestureListener _listener;
		readonly Android.Views.GestureDetector _detector;
		public FrameWithLongTouchGestureRenderer()
		{
			_listener = new MyGestureListener();
			_detector = new GestureDetector(_listener);
		}
		
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				view = e.NewElement as FrameWithLongTouchGesture;
				UpdateEventHandlers();
			}
		}
		
		private void UpdateEventHandlers()
		{
			_listener.MyFrame = view;
			GenericMotion += (s, a) => _detector.OnTouchEvent(a.Event);
			Touch += (s, a) => _detector.OnTouchEvent(a.Event);
		}
	}
