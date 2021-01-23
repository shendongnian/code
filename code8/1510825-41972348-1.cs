    class Events
    {
        public void GenerateBaseEvent()
        {
            // for this device must be discoverable and and its account and uri must be known
            var sessionFactory = new NvtSessionFactory(deviceparam.Account); // deviceparam is camera and account contaion its username and password
            var sess = sessionFactory.CreateSession(uri);
            OdmSession os = new OdmSession(sess);
            os.GetBaseEvents(9865)// some random port number
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
