    public async Task<ActionResult> Index()
    {
    
        //Things that run on main Asp.NET thread
    
         //Things that run independently
         //should it be DoSomethingAsync1().ConfigureAwait(false)? 
         //Or maybe, var task = DoSomethingAsync1();
         //Won't be using the task returned here at the moment. Returning Task<User> instead of void as it may help with catching exceptions if needed
         await DoSomethingAsync1();
    
         //Do more things on main Asp.NET thread if needed
         return View();             
    
    }
