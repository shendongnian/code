    void Main()
    {
    	var ev = GetMockedEvent();
    	foreach (var msg in ev)
    	{
    	    Console.WriteLine(msg);
    	}
    }
    
    public abstract class Event : IEnumerable<Message>, IEnumerable
    {
        protected Event() { }
        public abstract bool IsValid { get; }
        public IEnumerator<Message> GetEnumerator() { throw new NotImplementedException(); }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerable<Message> GetMessages() { throw new NotImplementedException(); }     
    }
    
    public class Message { }
    
    public static Event GetMockedEvent()
    {
        var mock = new Mock<Event>();
        mock.Setup(e => e.IsValid).Returns(true);
        mock.As<IEnumerable<Message>>().Setup(e => e.GetEnumerator()).Returns(MessageList());
    	// The next line doesn't work either because the method is not virtual
        //mock.Setup(e => e.GetEnumerator()).Returns(MessageList());
    
        return mock.Object;
    }
    
    private static IEnumerator<Message> MessageList()
    {
        yield return GetMockedMessage();
        yield return GetMockedMessage();
    }
    
    private static Message GetMockedMessage()
    {
        var mock = new Mock<Message>();
        // Unimportant setups...
        return mock.Object;
    }
