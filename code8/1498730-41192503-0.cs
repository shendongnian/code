    if (paramType.IsValueType) {
         ilGen.Emit(OpCodes.Unbox, paramType);
         ilGen.Emit(OpCodes.Ldobj, paramType);
    }
    else {
          ilGen.Emit(OpCodes.Castclass, paramType);
    }
