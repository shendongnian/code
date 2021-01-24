    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Connection 
    {
       public Int32 From;
       public Int32 To;
       public Double Weight;
    };
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct ListElement{ 
      public IntPtr next;
      public IntPtr element; 
    };
