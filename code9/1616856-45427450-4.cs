        public void DoTheWork()
        {
            using (var client = _clientFactory.GetClient(host, userName, password, timeout))
            {
                client.DownloadFile();
            } 
        }
