    Public class repository: dbcontext
    {
     public IDbset<car> Cras {get;  set;} 
    Public IQueryable<T> Get<T>()
    {
    return this.gettype().getproberties().find(x=>.  x.propertytype== typeof(T)). Getvalue(this)  as IQueryable<T>;
    }
    }
