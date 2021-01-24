    var returnType = GetObjectType(e1);
    if(typeof(IEnumerable).IsAssignableFrom(returnType))
    {
        myContext.Entry(AttachedObject).Collection(ex1).IsModified = true;
    }
    else if(returnType.IsClass) 
    {
        myContext.Entry(AttachedObject).Reference(ex1).IsModified = true;
    }
    else
    {
        myContext.Entry(AttachedObject).Property(ex1).IsModified = true;
    }
