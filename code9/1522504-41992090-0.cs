    public async Task<IHttpActionResult> doSomething(arguments) {  
        //... Perform some operation which includes some async database transactions
    
        if(operation succesed) {
            NotificationsAsync(userid); //Start notifications and continue
        }
    
        return result;
    }
