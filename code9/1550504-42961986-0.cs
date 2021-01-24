	public override Func version => (jobject, parameters) => 
    { 
        bool hasValidObject = false;
		for (int i = 1; i<7;i++) 
		{
	    	hasValidObject = this.SetVersionInfo(i) || hasValidObject;
		}
	    if (hasValidObject)
	    {
	        return GenerateSuccess();
	    }
	    return GenerateUnsuccessful( "try again.");
	};
	private bool SetVersionInfo(int i)
	{
		if (jobject["Version" + i] == null) return false;
	    
		_radio.GetType().GetProperty(propName)
			.SetValue(_radio, new VersionInfo(jobject["Version" + i].Value<string>()));
	    return true;
	}
