    [HubName("NotificationsHubs")]
    public class NotificationsHubs : Hub
    {
    
        public static Thread NotificationsThread;
        public void Send(string token, string UserAgent, string IP)
        {
            var serverVars = Context.Request.GetHttpContext().Request.ServerVariables;
            string SignalRIp = serverVars["REMOTE_ADDR"];
    
            string T = Context.Request.Headers["User-Agent"].ToLower();
            if ((T == cryptClass.crypt.Decrypt(UserAgent))  && (SignalRIp == cryptClass.crypt.Decrypt(IP)))
            {
                var connection = SignalRConnections.Connections.SingleOrDefault(c => c.Token == Guid.Parse(token));
                if (connection != null)
                {
                    connection.Context = this.Context;
                }
    
                if (NotificationsThread == null || !NotificationsThread.IsAlive)
                {
                   NotificationsThread = new Thread(new ThreadStart(NotificationsCheck));
                    NotificationsThread.Start();
                }
            }
       
