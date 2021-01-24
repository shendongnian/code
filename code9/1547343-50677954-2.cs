    [DataContract]
    public class Config
    {
    	[DataMember]
    	public Dictionary<string, string> ConnectionStrings { get; set; }
    	[DataMember]
    	public PluginCollection Plugins { get; set; }
    }
    
    [DataContract]
    public class PluginCollection
    {
    	[DataMember]
    	public Dictionary<string, SmsConfiguration> Sms { get; set; }
    	[DataMember]
    	public Dictionary<string, EmailConfiguration> Smtp { get; set; }
    }
    
    [DataContract]
    public class SmsConfiguration
    {
    	[DataMember]
    	public string Scheme { get; set; }
    	[DataMember]
    	public string Host { get; set; }
    	[DataMember]
    	public int Port { get; set; }
    	[DataMember]
    	public string Path { get; set; }
    	[DataMember]
    	public string Username { get; set; }
    	[DataMember]
    	public string Password { get; set; }
    	[DataMember]
    	public string Source { get; set; }
    	[DataMember]
    	public bool DeliveryReporting { get; set; }
    	[DataMember]
    	public string Encoding { get; set; }
    }
    
    [DataContract]
    public class EmailConfiguration
    {
    	[DataMember]
    	public string Scheme { get; set; }
    	[DataMember]
    	public string Host { get; set; }
    	[DataMember]
    	public int Port { get; set; }
    	[DataMember]
    	public string Path { get; set; }
    	[DataMember]
    	public string Username { get; set; }
    	[DataMember]
    	public string Password { get; set; }
    	[DataMember]
    	public string DefaultSender { get; set; }
    	[DataMember]
    	public bool EnableSsl { get; set; }
    }
