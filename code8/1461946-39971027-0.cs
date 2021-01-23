    public static class Settings
    {
        public static string ApplicationName { get; set; }
        public static string ServerName { get; set; }
        public static int PortNumber { get; set; }
        public static void Initialise(string applicationName, string serverName, int portNumber)
        {
            ApplicationName = applicationName;
            ServerName = serverName;
            PortNumber = portNumber;
        }            
    }
