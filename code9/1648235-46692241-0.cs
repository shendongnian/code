	[HttpGet("getordersasxml/{customerNumber}")]
	public string GetOrdersAsXml(string customerNumber)
	{
        //return _orderBL.GetOrdersAsXml(customerNumber); // Gives trouble!
		
        // Put xml as a byte array into a json
        var xml = _orderBL.GetOrdersAsXml(customerNumber);
		var response = JsonConvert.SerializeObject(new
		{
			data = Encoding.UTF8.GetBytes(xml)
		}); 
		return response;
	}
