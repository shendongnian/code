	public interface IMessageStore
	{
		IEnumerable<string> GetMessages();
		void AddMessage(string message);
	}
	public class MessageStore : IMessageStore
	{
		private List<string> _messages = new List<string>();
		public IEnumerable<string> GetMessages()
		{
			return _messages.ToList();
		}
		public void AddMessage(string message)
		{
			_messages.Add(message);
		}
	}
