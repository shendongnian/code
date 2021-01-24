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
                _myStringWithEvent = value;
				if (value != null && value != String.Empty)
				{
					if (HasMessage != null)
						HasMessage(this, EventArgs.Empty);
				}
			}
		}
	}
