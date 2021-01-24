	var obj = new
	{
		type = "login",
		condition = new Dictionary<string, object>()
		{
			{ "0", new { key = "email", value = "myEmail" } },
			{ "1", new { key = "password", value = "myPassword" } }
		}
	};
	string json = new JavaScriptSerializer().Serialize(obj);
