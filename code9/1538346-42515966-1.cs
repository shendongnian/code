    public class btc {
      public usd usd {get;set;}
    }
    public class usd....
    
    var btcLoaded = JsonConvert.DeserializeObject<btc>(jsonString);
    var lastBitstamp = btc.usd.bitstamp.last;
