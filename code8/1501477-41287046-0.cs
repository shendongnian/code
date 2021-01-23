    var t = typeof(T);
    var pInfos = t.GetProperties(BindingFlags.Public|BindingFlags.Instance).Where(x=>x.Name!="ID" && x.CanRead).ToArray();
    Expression exp=null;
    Expression pT = Expression.Parameter(t);
    foreach(var p in pInfos)
    {
    Expression m = Expression.Property(pT,p);
    Expression c = Expression.Constant(p.GetValue(entity));
    if(tmp==null)
    {
    tmp=Expression.Equal(m,c);
    }
    else
    {
    tmp=Expression.AndAlso(tmp,Expression.Equal(m,c));
    }
    }
    var myLambda=Expression.Lambda<Func<T,bool>>(tmp,pT);
    
    
    return myDbSet.AsQueryable().Any(myLambda);
