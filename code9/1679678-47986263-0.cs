    public class Proxy
    {
       public string Host { get; set; }
       public int Port { get; set; }
       public DateTime LastSuccess { get; set; }
    
       public Proxy(string value)
       {
          var proxySplit = value.Split(':');
          Host = proxySplit[0];
          Port = Convert.ToInt32(proxySplit[1]);
          LastSuccess = DateTime.MinValue;
       }
    }
      
