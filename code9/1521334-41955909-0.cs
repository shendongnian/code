    public List<MyClass> GetData(Category category, bool flag = true)
    {
        var result = Session.All<MyClass>()
    		.Where(mc => mc.Col.Equals(category.ToString()));
    	
    	if (flag) {
    		result = result.Where(mc => mc.FLAG);
    	}
        
        return result.ToList();
    }
