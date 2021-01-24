    public async Task SendMessage(string number, string body)
    {
    	var from = _config["SMSSenderSettings:FromNumber"];
    	var username = _config["SMSSenderSettings:PanelUserName"];
    	var password = _config["SMSSenderSettings:PanelPassword"];
    
    	using (var client = new HttpClient())
    	{
    		try
    		{
    			var response = await client.GetAsync($"{BaseUrl}/send.php?method=sendsms&format=json&from={from}" +
    				$"&to={number}&text={body}&type=0&username={username}&password={password}");
    			response.EnsureSuccessStatusCode(); // Throw exception if call is not successful
    
    			await response.Content.ReadAsStringAsync();
    		}
    		catch (HttpRequestException)
    		{
    			
    		}
    	}
    }
