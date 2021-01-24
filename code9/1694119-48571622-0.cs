    public async Task<IHttpActionResult> add(Model clientModel)
    {
        var user = clientModel.model;
        //Do whatever you need with user
        
        //Save the object in database
        user.Save();
    }
