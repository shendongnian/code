    protected override bool IsAuthorized(HttpActionContext actionContext)
    {
        var response = mydata.Result.Content.ReadAsStringAsync();
        if (mydata.Result.StatusCode == HttpStatusCode.OK)
        {
		    string someValue = "any value";
            actionContext.Request.Properties.Add(new KeyValuePair<string, object>("YourKeyName", someValue));
            return true;
        }
    }
