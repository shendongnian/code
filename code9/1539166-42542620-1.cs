    public Order[] GetAllOrders()
    {
    	Order[] result = null;
    	string orderString = "";
    
    	try
    	{
    		StringBuilder orders = new StringBuilder("[");
    		String jsonResponse = BigCommerceGet("orders?limit=50&page=1");
    		int page = 1;
    		string prePend = "";
    
    		while (jsonResponse != "")
    		{
    			// Remove the leading and trailing brackets, and prepend a comma
    			// beyond page 1.
    			orders.Append(prePend + jsonResponse.Substring(1, jsonResponse.Length - 2));
    			prePend = ",";
    			page++;
    			jsonResponse = BigCommerceGet("orders?limit=50&page=" + page.ToString());
    		}
    
    		orders.Append("]");
    
    		System.IO.FileStream wFile;
    		byte[] byteData = null;
    		byteData = Encoding.ASCII.GetBytes(orders.ToString());
    		using (wFile = new FileStream(@"Z:\ThisIsYourFile.txt", FileMode.Create))
    		{
    			wFile.Write(byteData, 0, byteData.Length);
    			wFile.Close();
    		}
    
    		orderString = orders.ToString();
    		result = JsonConvert.DeserializeObject<Order[]>(orderString);
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine("*** Exception encountered while retrieving store information: {0}", e.ToString());
    	}
    
    	return result;
    }
