    var getMethod = tb.DefineMethod("get_" + propertyName,
                                       MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,        
                                       propertyType,
                                       Type.EmptyTypes);
    var setMethod = tb.DefineMethod("set_" + propertyName,
                                       MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,        
                                       null,
                                       new [] { propertyType });
