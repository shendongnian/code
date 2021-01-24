    [Serializable]
	public class Message
	{
		public event EventHandler HasMessage;
		public string _myStringWithEvent;
		public string MyStringWithEvent
		{
			get { return _myStringWithEvent; }
			set
			{
				if (value != _myStringWithEvent && value != null && value != String.Empty)
				{
					_myStringWithEvent = value;
					if (HasMessage != null)
						HasMessage(this, EventArgs.Empty);
				}
			}
		}
	}
