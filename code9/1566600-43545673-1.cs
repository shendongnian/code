    IEnumerable<Type> FindDtoTypes()
    {
    foreach (var item in GetType().Assembly.GetTypes()) 
    {
        foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
        {
            var meth = member as MethodBase;
            if (meth != null && meth.GetMethodBody() != null)
            {
                var code = meth.GetMethodBody().GetILAsByteArray();
                foreach (var instr in Decompile(meth, code))
                {
                    var oper = instr.Operand as MethodBase;
                    if (oper != null && oper.IsConstructor &&
                        oper.DeclaringType.IsGenericType)
                    {
                        var dtoType = mb.DeclaringType.GetGenericArguments().First();
                        if (dtoType.IsAssignableFrom(oper.DeclaringType))
                            yield return oper.DeclaringType;
                    }
                }
            }
        }
    }
    }
