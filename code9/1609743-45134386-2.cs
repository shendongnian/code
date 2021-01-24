    [DllImport("UNZDLL32.DLL", CharSet = CharSet.Auto)]
    public static extern void UNZ_GETERRORTEXT(long hUnz, StringBuilder ErrorText);
    // or
    [DllImport("UNZDLL32.DLL", CharSet = CharSet.Auto)]
    public static extern void UNZ_GETERRORTEXT(long hUnz, ref string ErrorText);`
