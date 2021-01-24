    public class Message
    {
        public string address { get; set; }
        public string body { get; set; }
        public string _id { get; set; }
        public string msg_box { get; set; }
        public string sim_slot { get; set; }
    }
    public class RootObject
    {
        public string limit { get; set; }
        public string offset { get; set; }
        public string size { get; set; }
        public List<Message> messages { get; set; }
    }
