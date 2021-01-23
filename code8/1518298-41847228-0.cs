    class Server
    {
         public string HostName { get; private set; }
         public bool IsOnline { get; private set; }
         public Server(string hostName)
         {
            HostName = hostName;
         }
         
         public bool CheckState()
         {
            IsOnline = YourLogicForChecking(HostName);
            return IsOnline;
         }
    }
