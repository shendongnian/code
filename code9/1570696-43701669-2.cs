    .method private hidebysig static void  C<valuetype .ctor ([mscorlib]System.ValueType) T>(object o) cil managed
    {
      // Code size       48 (0x30)
      .maxstack  3
      .locals init (valuetype [mscorlib]System.Nullable`1<!!T> V_0)
      IL_0000:  ldarg.0
      IL_0001:  isinst     valuetype [mscorlib]System.Nullable`1<!!T>
      IL_0006:  unbox.any  valuetype [mscorlib]System.Nullable`1<!!T>
      IL_000b:  stloc.0
      IL_000c:  ldloca.s   V_0
      IL_000e:  call       instance bool valuetype [mscorlib]System.Nullable`1<!!T>::get_HasValue()
      IL_0013:  brfalse.s  IL_002f
      IL_0015:  ldstr      "Argument is {0}: {1}"
      IL_001a:  ldtoken    !!T
      IL_001f:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0024:  ldloc.0
      IL_0025:  box        valuetype [mscorlib]System.Nullable`1<!!T>
      IL_002a:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object,
                                                                    object)
      IL_002f:  ret
    }
