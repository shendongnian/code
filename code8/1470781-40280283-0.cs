    [DataContract]
    public class TestMessage
    {
        private int clientId;
        [DataMember(Order = 1)]
        public int ClientId
        {
            get { return clientId; }
            private set { clientId = value; }
        }
        private string name;
        [DataMember(Order = 2)]
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        protected TestMessage() { }
        public TestMessage(int clientId, string name)
        {
            this.clientId = clientId;
            this.name = name;
        }
    }
