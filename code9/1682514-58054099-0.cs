    var type1 = new CodeTypeReference("Type1");
    var type2 = new CodeTypeReference("Type2");
    var genericType = new CodeTypeReference("GenericType");
    genericType .TypeArguments.Add(tupleType);
    genericType .TypeArguments.Add(returnType);
