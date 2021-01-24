    public static T EntityGet<T>(Guid id, OrganizationServiceContext xrmServiceContext) where T : Entity
    {           
        try
        {
            return xrmServiceContext.CreateQuery<T>().SingleOrDefault(query => query.Id == id);
        }
        catch (Exception)
        {
            // Log the exception or this could create a debugging nightmare down the road!!!
            return default(T);
        }            
    }
