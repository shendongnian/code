    class MessageFilter : IMessageFilter
	{
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == 0x0203)
			{
				m.Result = IntPtr.Zero;
				return true;
			}
			else
				return false;
		}
	}
