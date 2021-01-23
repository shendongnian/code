    class MappingDbDataReader : DelegatingDbDataReader
    {
    	Dictionary<string, string> nameToSourceNameMap;
    	public MappingDbDataReader(DbDataReader source, Dictionary<string, string> nameToSourceNameMap) : base(source)
    	{
    		this.nameToSourceNameMap = nameToSourceNameMap;
    	}
    	private string GetSourceName(string name)
    	{
    		string sourceName;
    		return nameToSourceNameMap.TryGetValue(name, out sourceName) ? sourceName : name;
    	}
    	public override object this[string name]
    	{
    		get { return base[GetSourceName(name)]; }
    	}
    	public override string GetName(int ordinal)
    	{
    		string sourceName = base.GetName(ordinal);
    		return nameToSourceNameMap
    			.Where(item => item.Value.Equals(sourceName, StringComparison.OrdinalIgnoreCase))
    			.Select(item => item.Key)
    			.FirstOrDefault() ?? sourceName;
    	}
    	public override int GetOrdinal(string name)
    	{
    		return base.GetOrdinal(GetSourceName(name));
    	}
    }
