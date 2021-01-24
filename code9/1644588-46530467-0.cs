    .method public hidebysig specialname 
        instance class [mscorlib]System.Collections.Generic.IList`1<string> get_Get () cil managed 
    {
        // Method begins at RVA 0x2063
        // Code size 7 (0x7)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: ldfld class [mscorlib]System.Collections.Generic.IList`1<string> DatabaseModules.Test::_cache
        IL_0006: ret
    } // end of method Test::get_Get
    .method public hidebysig specialname 
        instance class [mscorlib]System.Collections.Generic.IList`1<string> get_GetOld () cil managed 
    {
        // Method begins at RVA 0x2063
        // Code size 7 (0x7)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: ldfld class [mscorlib]System.Collections.Generic.IList`1<string> DatabaseModules.Test::_cache
        IL_0006: ret
    } // end of method Test::get_GetOld
