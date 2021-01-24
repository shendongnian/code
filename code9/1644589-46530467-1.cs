    .method public hidebysig specialname 
        instance class [mscorlib]System.Collections.Generic.IList`1<string> get_Get () cil managed 
    {
        // Method begins at RVA 0x2065
        // Code size 7 (0x7)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: ldfld class [mscorlib]System.Collections.Generic.IList`1<string> DatabaseModules.Test::_cache
        IL_0006: ret
    } // end of method Test::get_Get
    .method public hidebysig specialname 
        instance class [mscorlib]System.Collections.Generic.IList`1<string> get_GetOld () cil managed 
    {
        // Method begins at RVA 0x2070
        // Code size 12 (0xc)
        .maxstack 1
        .locals init (
            [0] class [mscorlib]System.Collections.Generic.IList`1<string>
        )
        IL_0000: nop
        IL_0001: ldarg.0
        IL_0002: ldfld class [mscorlib]System.Collections.Generic.IList`1<string> DatabaseModules.Test::_cache
        IL_0007: stloc.0
        IL_0008: br.s IL_000a
        IL_000a: ldloc.0
        IL_000b: ret
    } // end of method Test::get_GetOld
