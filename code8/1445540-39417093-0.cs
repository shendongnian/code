    private static string CreateOutput(CreateTrialUserHubspotViewModel trialUser)
    {
    	var properties = trialUser.GetType().GetProperties().Where(x => Attribute.IsDefined(x, typeof(HubspotAttribute))).ToList();
    
    	var values = properties.Select(x =>
    	{
    		var att = x.GetCustomAttribute(typeof(HubspotAttribute));
    		var key = att.GetType().GetField("hubspotValue").GetValue(att);
    		var val = x.GetValue(trialUser);
    		return $"{key}:{val}";
        });
    
    	var sb = new StringBuilder();
    	values.ToList().ForEach(v =>
    	{
    		sb.Append(v);
    		if (values.Last() != v) sb.Append(',');
    	});
    	
    	return sb.ToString();
    }
