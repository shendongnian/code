        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MySubType
        {
            public int a;
            public double b;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MyInput
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string aString; //A string of length 3 
            public bool aBoolean;       
            public int anInt;
            public char aChar;
            public double aDouble;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 12)]
            public MySubType[] aSubType; //Array of struct of length 12
        }
