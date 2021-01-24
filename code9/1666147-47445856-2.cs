    //assumes ctor contains a reference to the 
    //concrete generic type's version of the constructor
    public Type GetDeclaringType(ConstructorInfo ctor) {
        var type = ctor.DeclaringType;//Gets the class that declares this member.
        var typeInfo = type.GetTypeInfo();//Returns TypeInfo representation of specified type.
        if (typeInfo.IsGenericType) {
            type = typeInfo.GetGenericTypeDefinition();
        }
        return type;
    }
