    var returnType = GetObjectType(e1);
    if(returnType.IsClass) 
    {
        myContext.Entry(AttachedObject).Reference(ex1).IsModified = true;
    }
    else
    {
        myContext.Entry(AttachedObject).Property(ex1).IsModified = true;
    }
