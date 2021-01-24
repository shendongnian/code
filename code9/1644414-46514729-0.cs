    public void MyMethod(string orderBy)
    {
    	// Assuming Product has 'Name' and 'Age' property ?
        var dico = new Dictionary<string, Expression<Func<Product,object>>>
        {
            { "property1", x => x.Name},
            { "property2", x => x.Age},
        };
    
    	Expression<Func<Product,object>> myorder;
        dico.TryGetValue("property1", out myOrder);
    
        _context.Products.OrderBy(myOrder);
    }
