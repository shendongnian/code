    [WebMethod]
    protected static string GetData()
    {
        var results = (from x in EFDB.AspNetRoles
                       select new 
    				   {
    					 Id= x.Id,
    					 Name = x.Name
    				   });
    
        return JsonConvert.SerializeObject(results.ToArray());
    }
