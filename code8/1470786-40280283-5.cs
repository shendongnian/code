    public class TestMessage
    {
        private readonly int clientId;
        public int ClientId
        {
            get { return clientId; }
        }
        private readonly string name;
        public string Name
        {
            get { return name; }
        }
        public TestMessage(int clientId, string name)
        {
            this.clientId = clientId;
            this.name = name;
        }
    }
    [DataContract]
    internal class TestMessageSurrogate
    {
        public static implicit operator TestMessageSurrogate(TestMessage message)
        {
            if (message == null)
                return null;
            return new TestMessageSurrogate { ClientId = message.ClientId, Name = message.Name };
        }
        public static implicit operator TestMessage(TestMessageSurrogate message)
        {
            if (message == null)
                return null;
            return new TestMessage(message.ClientId, message.Name);
        }
        [DataMember(Order = 1)]
        public int ClientId { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
