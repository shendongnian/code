    class SftpClientFactory : ISftpClientFactory
    {
        public SftpClient GetClient(string host, string userName, string password, int timeout)
        {
            return new SftpClient(host, userName, password, timeout);
        }
    }
