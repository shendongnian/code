    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public class SomeClass
    {
        public string[] strings()
        {
            string[] strs = new string[4];
            strs[0] = string1;
            strs[1] = string2;
            strs[2] = string3;
            strs[3] = string4;
        }
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string string1; // 16 Byte String
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string string2; // 16 Byte String
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string string3; // 16 Byte String
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string string4; // 16 Byte String
    }
 
