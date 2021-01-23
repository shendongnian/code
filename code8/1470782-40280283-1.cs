    [DataContract]
    public class TestMessage
    {
        [DataMember(Name = "ClientId", Order = 1)]
        private int clientId;
        public int ClientId
        {
            get { return clientId; }
        }
        [DataMember(Name = "Name", Order = 2)]
        private string name;
        public string Name
        {
            get { return name; }
        }
        protected TestMessage() { }
        public TestMessage(int clientId, string name)
        {
            this.clientId = clientId;
            this.name = name;
        }
    }
