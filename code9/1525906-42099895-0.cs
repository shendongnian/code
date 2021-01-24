    class Server
    {
        private TcpListener _listener = new TcpListener(12312);            
        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var client = _listener.AcceptTcpClient();
                var stream = client.GetStream();
                var request = getRequest(stream);
                if (request == "GetDelimiter")
                {
                    SendResponse(Utils.DELIMITER, stream);
                }
                else
                {
                    ProcessNameSurnameAge(request);
                }
            }
        }
    }
    
    class Client
    {
        private TcpClient _client = new TcpClient();
        public void DoTheThing()
        {
            _client.Connect("127.0.0.1", 12312);
            var stream = _client.GetStream();
            SendRequest("GetDelimiter", stream);
            var delimiter = GetResponse(stream);
            var newRequest = "some Name" + delimiter + "some Surname" + delimiter + "some Age" + delimiter + "something else";
            SendRequest(newRequest);
        }
    }
