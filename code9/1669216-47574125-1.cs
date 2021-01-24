	public static void Main()
	{		
		var url = "https://bittrex.com/api/v1.1/public/getmarketsummary?market=usdt-btc";
        // for a simple get, use WebClient
		var json = new WebClient().DownloadString(url);
		
        // learn more on https://www.newtonsoft.com/json
		var root = JsonConvert.DeserializeObject<RootObject>(json);
		
        // root.Results.Last() is your last item
        // learn more on Last() at https://msdn.microsoft.com/fr-fr/library/bb358775(v=vs.110).aspx
		Console.WriteLine(root.Results.Last().TimeStamp);
	}
	
    // generated with http://json2csharp.com/ (VS has a builtin with edit>past special)
	public class Result
	{
	    public string MarketName { get; set; }
    	public double High { get; set; }
    	public double Low { get; set; }
    	public double Volume { get; set; }
    	public double Last { get; set; }
    	public double BaseVolume { get; set; }
    	public DateTime TimeStamp { get; set; }
    	public double Bid { get; set; }
    	public double Ask { get; set; }
    	public int OpenBuyOrders { get; set; }
    	public int OpenSellOrders { get; set; }
    	public double PrevDay { get; set; }
   	 	public DateTime Created { get; set; }
	}
	public class RootObject
	{
    	public bool Success { get; set; }
    	public string Message { get; set; }
    	public List<Result> Results { get; set; }
	}
