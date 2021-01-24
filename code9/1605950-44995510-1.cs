            private static void CreateMethod(TypeBuilder typeBuilder, MethodInfo method, FieldInfo proxyFiled)
            {
                var paramters = method.GetParameters();
    
                var methodBuilder = typeBuilder.DefineMethod(method.Name,
                    MethodAttributes.Public 
                    | MethodAttributes.Virtual
                    | MethodAttributes.HideBySig
                    | MethodAttributes.SpecialName,
                    CallingConventions.Standard,
                    method.ReturnType,
                    paramters.Select(x => x.ParameterType).ToArray()); // change this line
    
                var il = methodBuilder.GetILGenerator();
               
                il.DeclareLocal(typeof(Dictionary<string, object>)); // add this line
                il.Emit(OpCodes.Newobj, typeof(Dictionary<string, object>).GetConstructor(new Type[0]));
                il.Emit(OpCodes.Stloc_0);
    
                for (short i = 0; i < paramters.Length; ++i)
                {
                    var param = paramters[i];
    
    
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Ldstr, param.Name);
                    il.Emit(OpCodes.Ldarg, (short)(i +1));
    
                    if (param.ParameterType.GetTypeInfo().IsValueType)
                    {
                        il.Emit(OpCodes.Box, param.ParameterType);
                    }
    
                    il.Emit(OpCodes.Callvirt, typeof(Dictionary<string, object>).GetMethod("Add"));
                }
    
                var proxyMethod = typeof(RPCRequestProxy)
                    .GetMethods()
                    .First(x => x.Name == "PostAsync" && x.GetParameters().Length == 2);
    
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, proxyFiled);
                il.Emit(OpCodes.Ldstr, "xxx.xxx.xxx");
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Callvirt, proxyMethod);
                il.Emit(OpCodes.Ret);
            }
