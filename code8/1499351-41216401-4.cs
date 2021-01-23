	public class TouchEventArgs<T> : EventArgs
	{
		public T EventData { get; private set; }
		public TouchEventArgs(T EventData)
		{
			this.EventData = EventData;
		}
	}
	public interface IGlobalTouch
	{
		void Subscribe(EventHandler handler);
		void Unsubscribe(EventHandler handler);
	}
