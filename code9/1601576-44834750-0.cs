    public await Task<JsonResult> Save(User eUser, Request eRequest)
    {
        await Execute();
    
        try
        {
            //Look at it later
            eUser.Password = EncryptHelper.EncryptString(eUser.Password, "kahat");
            eUser.Password1 = EncryptHelper.EncryptString(eUser.Password1, "kahat123");
            this.rpGeneric.SaveOrUpdate<User>(eUser);
            this.rpGeneric.SaveOrUpdate<Request>(eRequest);
            return GetAll();
        }
        catch (Exception ex)
        {
            return ThrowJsonError(ex);
        }
    }
