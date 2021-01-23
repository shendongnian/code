    public class stations
    {
      public string station_code { get; set; }
      public string atcocode {get; set; }
    }
    
    public class Data
    {
     public DateTime request_time {get; set; }
     public IEnumerable<stations> Stations {get; set; }
    }
    
    var result = JsonConvert.DeserializeObject<Data>(json);
    
    foreach(stations s in result.Stations)
    {
      Console.WriteLine(s.station_code);
    }
