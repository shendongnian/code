	var obj = JObject.FromObject(new
	{
		attachment = new
		{
			type = "template", 
            payload = new
			{
				template_type = "button", 
                text = Title, 
                buttons = new object[] 
                { 
                    new Dictionary<string,object>() 
                    {
						{ "type", "type" },
						{ Variable1, Value },
						{ Variable2, Payload }
				    }
                }
			}
		}
	});
