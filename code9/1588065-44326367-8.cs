    // this is class that represents single device
    public class AssetTracker
    {
       public AssetTracker()
       {
          latitude = new List<string>();
          longitude = new List<string>();
       }
       public string deviceid {get; set;}
       public List<string> latitude {get; set;}
       public List<string> longitude {get; set;}
    }   
