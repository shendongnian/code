    class Server
    {
    	public string IP { get; set; }
    	public int Port { get; set; }
    	public string PathToCSV { get; set; }
    }
    
    class Client
    {
    	public bool RestartComputerAfterScript { get; set; }
    	public List<string> Install { get; set; }
    	public string TempLoc { get; set; }
    }
    
    class Config
    {
    	public Server ServerConfig { get; set; }
    	public Client ClientConfig { get; set; }
    }
