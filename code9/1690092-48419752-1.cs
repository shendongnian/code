    .class private auto ansi '<Module>'
    {
    } // end of class <Module>
    
    .class public auto ansi beforefieldinit C
        extends [mscorlib]System.Object
    {
        // Fields
        .field private class A A
    
        // Methods
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            // Method begins at RVA 0x2050
            // Code size 18 (0x12)
            .maxstack 8
    
            IL_0000: ldarg.0
            IL_0001: newobj instance void A::.ctor()
            IL_0006: stfld class A C::A
            IL_000b: ldarg.0
            IL_000c: call instance void [mscorlib]System.Object::.ctor()
            IL_0011: ret
        } // end of method C::.ctor
    
        .method public hidebysig 
            instance void M () cil managed 
        {
            // Method begins at RVA 0x2063
            // Code size 1 (0x1)
            .maxstack 8
    
            IL_0000: ret
        } // end of method C::M
    
    } // end of class C
    
    .class public auto ansi beforefieldinit A
        extends [mscorlib]System.Object
    {
        // Methods
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            // Method begins at RVA 0x2065
            // Code size 7 (0x7)
            .maxstack 8
    
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib]System.Object::.ctor()
            IL_0006: ret
        } // end of method A::.ctor
    
    } // end of class A
