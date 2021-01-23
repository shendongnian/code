      .method /*06000002*/ private hidebysig static 
              class [mscorlib/*23000004*/]System.Collections.Generic.IEnumerable`1/*01000003*/<int32> 
              IndexWhereImpl<T>(class [mscorlib/*23000004*/]System.Collections.Generic.IEnumerable`1/*01000003*/<!!T> coll,
                                class [mscorlib/*23000004*/]System.Func`2/*01000004*/<!!T,bool> 'filter') cil managed
      {
        // Code size       8 (0x8)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldarg.1
        IL_0002:  newobj     instance void Testing.Linq_operatorModule/*02000002*//$IndexWhereImpl$3`1/*02000003*/::.ctor(class [mscorlib/*23000004*/]System.Collections.Generic.IEnumerable`1/*01000003*/<!!T>,
                                                                                                                          class [mscorlib/*23000004*/]System.Func`2/*01000004*/<!!T,bool>) /* 06000006 */
        IL_0007:  ret
      } // end of method Linq_operatorModule::IndexWhereImpl
