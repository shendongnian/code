    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public class SomeClass
    {
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public bool[] bs; // 8 times 1 Byte boolean
        
    }
