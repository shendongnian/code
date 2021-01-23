	public EventHandler globalTouchHandler;
	public override bool DispatchTouchEvent(MotionEvent ev)
	{
		if (globalTouchHandler != null)
			globalTouchHandler.Invoke(null, new TouchEventArgs<Point>(new Point(ev.GetX(), ev.GetY())));
		return base.DispatchTouchEvent(ev);
	}
