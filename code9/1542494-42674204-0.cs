    //get the dynamic type from somewhere
    Type unknownType = ...;
    //get open generic base type
    Type openGeneric = typeof(IQueryable<>);
    //create closed generic type with the unknown type as generic type parameter
    Type closedGeneric = openGeneric.MakeGenericType(unknownType);
    //use the closed type for whatever you want
    Type returnType = closedGeneric;
