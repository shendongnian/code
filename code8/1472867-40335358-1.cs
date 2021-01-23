     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
     public unsafe struct CustomerInfo
     {
          public sbyte* Id;
          public sbyte* Name;
          public sbyte* Address;
     }
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
     public unsafe struct CustomerList
     {
          public CustomerInfo* Info;
          public CustomerList* Next;
     };
