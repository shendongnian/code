    class Entity
        {
            public BsonObjectId _id { get; set; }
            public string email1 { get; set; }
            public string email2 { get; set; }
            public List<Message> messages { get; set; }
    
            public Entity()
            {
                messages = new List<Message>();
            }
        }
    
        class Message
        {
            public DateTime time { get; set; }
            public string room { get; set; }
            //...
            public string message_text { get; set; }
        }
