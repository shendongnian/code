	public class EventDemo {
		public event EventHandler SomeEvent;
		
		protected virtual void OnSomeEvent() {
			var someEvent = SomeEvent;
			if (someEvent != null) {
				someEvent(this, EventArgs.Empty);
			}
		}
	}
