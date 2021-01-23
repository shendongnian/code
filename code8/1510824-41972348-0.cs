    class Events
    {
       public void GenerateEvent()
        {
            // for this device must be discoverable and and its account and uri must be known
            var sessionFactory = new NvtSessionFactory(deviceparam.Account); // deviceparam is camera and account contaion its username and password
            var sess = sessionFactory.CreateSession(uri);
            OdmSession os = new OdmSession(sess);
            os.GetPullPointEvents()// this function contains function for the subscription and pull messages
                .Subscribe(
                evnt =>
                {
                    Console.WriteLine(EventParse.ParseTopic(evnt.topic));
                    var messages = EventParse.ParseMessage(evnt.message);
                    messages.ForEach(msg => Console.WriteLine(msg));
                }, err =>
                {
                    Console.WriteLine(err.Message);
                }
                );
        } 
    }
    public static class EventParse
    {
        public static string ParseTopic(TopicExpressionType topic) 
        {
            string topicString = "";
            topic.Any.ForEach(node => {
                topicString += "value: " + node.Value;
                });
                return topicString;
        }
        public static string[] ParseMessage(Message message) 
        {
            List<string> messageStrings = new List<string>();
            messageStrings.Add("messge id: " + message.key);
            if(message.source!= null)
                message.source.simpleItem.ForEach(sitem => 
                {
                    string txt = sitem.name + " " + sitem.value;
                    messageStrings.Add(txt);
                });
            if (message.data != null)
                message.data.simpleItem.ForEach(sitem => 
                {
                    string txt = sitem.name + " " + sitem.value;
                    messageStrings.Add(txt);
                });
            return messageStrings.ToArray();
        }
    }
