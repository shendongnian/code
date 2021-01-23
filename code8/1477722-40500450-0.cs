    class XComparer : IEqualityComparer<XElement>
    {
    	public IList<string> _exceptions;
    	public XComparer(params string[] exceptions)
    	{
    		_exceptions = new List<string>(exceptions);
    	}
    	
    	public bool Equals(XElement a, XElement b)
    	{
    		var attA = a.Attributes().ToList();
    		var attB = b.Attributes().ToList();
    
    		var setA = AttributeNames(attA);
    		var setB = AttributeNames(attB);
    
    		if (!setA.SetEquals(setB))
    		{
    			return false;
    		}
    
    		foreach (var e in setA)
    		{
    			var xa = attA.First(x => x.Name.LocalName == e);
    			var xb = attB.First(x => x.Name.LocalName == e);
    
    			if (xa.Value == null && xb.Value == null)
    				continue;
    				
    			if (xa.Value == null || xb.Value == null)
    				return false;
    
    			if (!xa.Value.Equals(xb.Value))
    			{
    				return false;
    			}
    		}
    		
    		return true;
    	}
    
    	public HashSet<string> AttributeNames(IList<XAttribute> e)
    	{
    		return new HashSet<string>(e.Select(x =>x.Name.LocalName).Except(_exceptions));
    	}
    
    	public int GetHashCode(XElement e)
    	{
    		var h = 0;
    		
    		var atts = e.Attributes().ToList();
    		var names = AttributeNames(atts);
    		
    		foreach (var a in names)
    		{
    			var xa = atts.First(x => x.Name.LocalName == a);
    
    			if (xa.Value != null)
    			{
    				h = h ^ xa.Value.GetHashCode();
    			}			
    		}
    		
    		return h;
    	}
    }
