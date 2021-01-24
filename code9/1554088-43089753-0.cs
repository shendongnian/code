    public string PizzaIngredients
    {
    	get
    	{
    		return String.Join(",",nringrediente);
    	}
    	set
    	{
    		nringrediente = value.Split(',');
    	}
    }
