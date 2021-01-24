       /*
          public char* pValue2;
          public fixed char Value3[1024];
          */
          [MarshalAs(UnmanagedType.LPStr)] public String pValue2;
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)] public String pValue3;
