    public override IQueryable<T> GetAll()
    {
        var result = base.GetAll();
    
        if (typeof(IHaveRoles).IsAssignableFrom(typeof(T)) && !AuthInfo.SignatureIsValid)
            result = result.Where("Roles.Any(Users.Any(Id == @0))", User.Id);
    
        return result;
    }
