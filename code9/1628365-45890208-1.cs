    .class public auto ansi beforefieldinit NoInit
        extends [mscorlib] System.Object
    {
        .field private bool _flag
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 8
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib] System.Object::.ctor()
            IL_0006: ret
        }
    }
    .class public auto ansi beforefieldinit DefaultInit
        extends [mscorlib] System.Object
    {
        .field private bool _flag
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 8
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib] System.Object::.ctor()
            IL_0006: ret
        }
    }
    .class public auto ansi beforefieldinit NonDefaultInit
        extends [mscorlib] System.Object
    {
        .field private bool _flag
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 8
            IL_0000: ldarg.0
            IL_0001: ldc.i4.1
            IL_0002: stfld bool NonDefaultInit::_flag
            IL_0007: ldarg.0
            IL_0008: call instance void [mscorlib] System.Object::.ctor()
            IL_000d: ret
        }
    }
    .class public auto ansi beforefieldinit TestDefaultCtor
        extends [mscorlib]System.Object
    {
        .field private bool _flag
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 8
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib]System.Object::.ctor()
            IL_0006: ldarg.0
            IL_0007: ldc.i4.0
            IL_0008: stfld bool TestDefaultCtor::_flag
            IL_000d: ret
        }
    }
    .class public auto ansi beforefieldinit TestNonDefaultCtor
        extends [mscorlib]System.Object
    {
        .field private bool _flag
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 8
            IL_0000: ldarg.0
            IL_0001: call instance void [mscorlib]System.Object::.ctor()
            IL_0006: ldarg.0
            IL_0007: ldc.i4.1
            IL_0008: stfld bool TestNonDefaultCtor::_flag
            IL_000d: ret
        }
    }
