    [Authorize]
    public IEnumerable<Object> Get()
    {
     var owner = ObtainCurrentOwner();
     var assets = GetAssets(owner.Id);
     return result;
    }
    
    protected Owner ObtainCurrentOwner()
    {
     return RavenSession.Query<Owner>().SingleOrDefault(x => 
               x.UserName == HttpContext.Current.User.Identity.Name);
    }
    
    public IEnumerable<Asset> GetAssets(int ownerID)
    {
     return RavenSession.Query<Asset>().Where(x => x.OwnerId == ownerID);
    }
