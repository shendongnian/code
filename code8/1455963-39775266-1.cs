    public class Server
    {
        public ServerType ServerType { get; set; }
        public bool IsDatabaseOrWeb
        {
            get
            {
                return ServerType == ServerType.Web || ServerType == ServerType.Database;
            }            
        }
    }
