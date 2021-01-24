	var obj = JObject.FromObject(new
	{
		attachment = new
		{
			type = "template", 
            payload = new
			{
				template_type = "button", 
                text = Title, 
                buttons = new Dictionary<string,object>() 
                {
						{ "type", "type" },
						{ Variable1, "value" },
						{ Variable2, "payload"}
				}
			}
		}
	});
