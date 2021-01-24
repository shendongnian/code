      var constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, new[] {typeof(string), typeof(string), typeof(Dictionary<string, Type>)});
      var ctorIl = constructorBuilder.GetILGenerator();
    
      for (var x = 0; x < backingFields.Count; x++) {
        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Ldarg_S, x + 1);
        ctorIl.Emit(OpCodes.Stfld, backingFields[x]);
      }
    
      ctorIl.Emit(OpCodes.Ret);
