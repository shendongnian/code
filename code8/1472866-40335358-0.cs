     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
     public unsafe struct CustomerInfo
     {
          public char* Id;
          public char* Name;
          public char* Address;
     }
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
     public unsafe struct CustomerList
     {
          public CustomerInfo* Info;
          public CustomerList* Next;
     };
