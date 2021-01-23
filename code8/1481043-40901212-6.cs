    public class RabbitOptions
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
    // In appsettings.json:
    {
      "Rabbit": {
        "hostName": "192.168.99.100",
        "username": "guest",
        "password": "guest",
        "port": 5672
      }
    }
