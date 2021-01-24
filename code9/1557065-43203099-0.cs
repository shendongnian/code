	public void GetBalance(string accountNumber,int officeId)
	{
		using (var client = new WebClient())
		{
			client.Headers.Add("Content-Type:application/json");
			client.Headers.Add("Accept:application/json");
			client.Headers.Add("API_KEY","1234CHECK");
			var uri = string.Concat("http://localhost/api/Accounts/GetBalance/", accountNumber, "/", officeId);
			var result = client.DownloadString(uri); //URI 
			Console.WriteLine(Environment.NewLine + result);
		}
	}
	static void Main(string[] args)
	{
		ConsumeApiSync objSync = new ConsumeApiSync();
		objSync.GetBalance("01-13-00000595", 1);
	}
