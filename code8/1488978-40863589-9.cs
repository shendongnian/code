    void Main()
    {
    	var samples = new[] { new Sample { A = "A", B = "B", C = "C" }, new Sample { A = "A1", B = "B2", C = "C1" } };
    	var r = samples.Select(e => getProperties(new[] {"A", "C", "B"}, e)).ToList();
    	r.Dump();
    }
    
    private object getProperty(Sample e, string propName)
    {
    	var propInfo = typeof(Sample).GetProperty(propName);
    	return propInfo.GetValue(e);
    }
    
    private dynamic getProperties(string[] props, Sample e)
    {
    	var ret = new ExpandoObject() as IDictionary<string, Object>; ;
    	foreach (var p in props)
    	{
    		ret.Add(p, getProperty(e, p));
    	}
    	return ret;
    }
    
    public class Sample
    {
    	public string A { get; set;}
    	public string B { get; set;}
    	public string C { get; set;}
    }
