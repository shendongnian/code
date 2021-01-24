    class Example
    {
        private readonly ISftpClientFactory _clientFactory;
  
        public Example(ISftpClientFactory injectedFactory)
        {
            _clientFactory = injectedFactory;
        }
        public void DoTheWork()
        {
            var client = _clientFactory.GetClient(host, userName, password, timeout);
        }
    }
