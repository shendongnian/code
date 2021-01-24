    private Func<object, object> GetGetDelegate()
    {
        Type setParamType = typeof(object);
        Type[] setParamTypes = { setParamType };
        Type setReturnType = typeof(object);
    
        Type owner = _targetType.GetTypeInfo().IsAbstract || _targetType.GetTypeInfo().IsInterface ? null : _targetType;
        var getMethod = owner != null
             ? new DynamicMethod(Guid.NewGuid().ToString(), setReturnType, setParamTypes, owner, true)
             : new DynamicMethod(Guid.NewGuid().ToString(), setReturnType, setParamTypes, true);
    
        // From the method, get an ILGenerator. This is used to
        // emit the IL that we want.
        ILGenerator getIL = getMethod.GetILGenerator();
    
        getIL.Emit(OpCodes.Ldarg_0); //Load the first argument (target object)
                                     
        if (_targetType.IsValueType)
            getIL.Emit(OpCodes.Unbox, _targetType); //unbox struct 
        else
            getIL.Emit(OpCodes.Castclass, this._targetType); //Cast to the source type
    
        Type returnType = null;
        if (IsField(_member))
        {
            getIL.Emit(OpCodes.Ldfld, (FieldInfo)_member);
            returnType = _memberType;
        }
        else
        {
            var targetGetMethod = ((PropertyInfo)_member).GetGetMethod();
            var opCode = _targetType.IsValueType ? OpCodes.Call : OpCodes.Callvirt;
            getIL.Emit(opCode, targetGetMethod);
            returnType = targetGetMethod.ReturnType;
        }
    
        if (returnType.IsValueType)
        {
            getIL.Emit(OpCodes.Box, returnType);
        }
    
        getIL.Emit(OpCodes.Ret);
    
        var del = getMethod.CreateDelegate(Expression.GetFuncType(setParamType, setReturnType));
        return del as Func<object, object>;
    }
       
