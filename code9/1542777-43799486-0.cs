    var ilg = ctor.GetILGenerator();
    ilg.Emit(OpCodes.Ldarg_0);        // load 'this' onto stack 
    ilg.Emit(OpCodes.Ldarg_1);        // load constructor argument onto the stack 
    ilg.Emit(OpCodes.Call, baseCtor); // call base constructor
    ilg.Emit(OpCodes.Ret);
