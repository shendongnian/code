    public static Type Find(string id, MainCat m)
    {
    	if (m.id.Equals(id))
    	{
    		return m.GetType();
    	}
    	if (m.subcat.Any(a => a.id.Equals(id)))
    	{
    		return typeof(subcat);
    	}
    	if (m.subcat.Any(a => a.subsubcat.Any(b => b.id.Equals(id))))
    	{
    		return typeof(subsubcat);
    	}
    	return null;
    }
