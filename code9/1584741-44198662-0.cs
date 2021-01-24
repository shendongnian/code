    public string Error
    {
    	get { return String.Empty; }
    }
     
    public string this[string columnName]
    {
    	get
    	{
    		String errorMessage = String.Empty;
    		switch (columnName)
    		{
    			case "Variable1":
    				if (String.IsNullOrEmpty(Variable1))
    				{
    					errorMessage = "Variable1 is required";
    				}
    				break;
    			case "Age":
    				if (Variable2 < 10)
    				{
    					errorMessage = "Variable2 can't be less than 10";
    				}
    				break;
    		}
    		return errorMessage;
    	}
    }
