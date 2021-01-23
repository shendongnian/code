	public class GlobalTouch : IGlobalTouch
	{
		public GlobalTouch() {}
		public void Subscribe(EventHandler handler)
		{
			(Forms.Context as MainActivity).globalTouchHandler += handler;
		}
		public void Unsubscribe(EventHandler handler)
		{
			(Forms.Context as MainActivity).globalTouchHandler -= handler;
		}
	}
