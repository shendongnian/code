    public string GetEntityInJson()
    {
       JavaScriptSerializer j = new JavaScriptSerializer();
       var entityList = dataContext.Entitites.toList();
       return j.Serialize(entityList );
    }
