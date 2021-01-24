    usingSystem.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Explicit)]
    public struct ExplicitStruct
    {
        [FieldOffset(0)] public Guid AGuid;
        [FieldOffset(0)] public long ALong;
    }
