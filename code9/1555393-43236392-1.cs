    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct MyStruct
    {
      public MyStruct(uint i)
      {
         // ......
        TestString = new char[5];
      }
    
      [MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
      public char[] TestString;  
    
    }
