    // your enumeration declaration ...
    private enum enum1 { A_1, B_1, C_1 }
    private enum enum2 { A_2, B_2, C_2 }
    private enum enum3 { A_3, B_3, C_3 }
    // string to process 
    private static string s = "A_1_B_2_C_3";
   
    // parsing result structure
    private struct ParsingResult
    {
        public Type enumType;
        public object enumValue;
    }
