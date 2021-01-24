    using(var client = new HttpClient())
    {
    	client.BaseAddress = new Uri("http://localhost:10000/");
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    	HttpResponseMessage response = await client.GetAsync("api/account/balance/" + accountNumber.ToString());
    	if (response.IsSuccessStatusCode)
    	{
    		string responseJson = await response.Content.ReadAsStringAsync();
    
    		JavaScriptSerializer jss = new JavaScriptSerializer();
    		var result = jss.Deserialize<AccountResponse>(responseJson);
    	}
    	else
    	{
    		Console.WriteLine("Error! Http error " + response.StatusCode.ToString());
    		Console.ReadLine();
    	}
    }
