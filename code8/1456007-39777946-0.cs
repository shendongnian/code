    // this is used by Expression.Equal (it does not search for base type)
    var m = typeof(Test).GetMethod("op_Equality", 
                BindingFlags.Static 
                | BindingFlags.Public | BindingFlags.NonPublic);
    //m is null because op_Equality is not declared on "Test"
    var m = typeof(ValueObject<>).GetMethod("op_Equality", 
                BindingFlags.Static 
                | BindingFlags.Public | BindingFlags.NonPublic);
    // m is not null
