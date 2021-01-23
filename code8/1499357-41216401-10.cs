	public EventHandler globalTouchHandler;
	public override bool DispatchTouchEvent(MotionEvent ev)
	{
		globalTouchHandler?.Invoke(null, new TouchEventArgs<Point>(new Point(ev.GetX(), ev.GetY())));
		return base.DispatchTouchEvent(ev);
	}
