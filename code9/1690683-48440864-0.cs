    namespace RequestA
    {
        public class RequestModel
        {
            [XmlElement("message", Namespace = "http://www.origostandards.com/schema/mtg/v2")]
            public Message.Message message { get; set; }
            public RequestModel()
            {
                this.message = new Message.Message();
            }
         }
    }
    namespace RequestB
    {
        public class RequestModel
        {
            [XmlElement("message", Namespace = "http://www.origostandards.com/schema/mtg/v2")]
            public Message.Message message { get; set; }
            public RequestModel()
            {
                this.message = new Message.Message();
            }
        }
    }
    namespace Message
    {
            public class Message
            {
                //other constructor here etc
            }
    }
