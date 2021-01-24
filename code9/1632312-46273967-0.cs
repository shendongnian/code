    [JSFunction(Name = "getHeaders")]
    public virtual ArrayInstance getHeaders(string name)
    {
    	IList<string> vals;
    	bool exists = _headers.TryGetValue(name, out vals);
    	if (!exists)
    	{
    		return this.Engine.Array.New();
    	}
    	return this.Engine.Array.New(vals.ToArray());
    }
