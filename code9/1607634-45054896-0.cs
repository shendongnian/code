    protected void Session_Start()
    {
        using(var entity = new OnlineStoreEntities){
            Session["Categories"] = entity.Categories.ToList();
        }
    }
