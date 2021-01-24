    static void Main(string[] args)
    {
        var helper = new TryCatchHelper();
        try
        {            
            using (var ss = new extest()) 
            {
                helper.Execute(() => {
                    // Your Code Block Here
                });              
            }
        }   
        catch(Exception ex)
        {
            // The Dispose threw an exception
        } 
        
        if (helper.Exception != null)
        {
            // Handle the exception from the block here.
        }   
    }
