    protected void Page_Load(object sender, EventArgs e)
    {
    	RegisterAsyncTask(new PageAsyncTask(ReadAsync));
    }
    
    protected async Task ReadAsync()
    {
    	string UrlData = await getFinalValue();
    
    	//continuation code..
    }
    
    protected async Task<string> getFinalValue()
    {
    	//my code to create string
    	 return "created string";
    }
