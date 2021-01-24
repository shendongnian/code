    [DllImport("UNZDLL32.DLL")]
    public static extern long UNZ_INIT_EX();
    [DllImport("UNZDLL32.DLL")]
    public static extern long UNZ_TERM (long hUnz);
    [DllImport("UNZDLL32.DLL", CharSet.Auto)]
    public static extern long UNZ_CHECKADDRESS(long hUnz, string Line1, string line2, string line3, string Line4);
    [DllImport("UNZDLL32.DLL", CharSet.Auto)]
    public static extern void UNZ_GETSTDADDRESS(long hUnz, string szFirmName, string szPRUrb, string szDelLine, string szLastLine);
    [DllImport("UNZDLL32.DLL", CharSet.Auto)]
    public static extern void UNZ_GETERRORTEXT(long hUnz, string ErrorText);
    [DllImport("UNZDLL32.DLL")]
    public static extern long UNZ_GETMATCHCOUNT(long hUnz);
    [DllImport("UNZDLL32.DLL", CharSet.Auto)]
    public static extern void UNZ_GETMATCHADDR(long hUnz, int intItem, string szFirmName, string szPRUrb, string szDelLine, string szLastLine);
    [DllImport("UNZDLL32.DLL", CharSet.Auto)]
    public static extern void UNZ_GETAREACODE(long hUnz, string szAreaCode);
