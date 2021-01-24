        internal struct Systime
        {
            internal UInt16 Year;
            internal UInt16 Month;
            internal UInt16 DayOfWeek;
            internal UInt16 Day;
            internal UInt16 Hour;
            internal UInt16 Minute;
            internal UInt16 Second;
            internal UInt16 Milliseconds;
        }
        internal struct FileTime
        {
            internal UInt32 dwLowDateTime;
            internal UInt32 dwHighDateTime;
        }
    [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
    private static extern bool DosDateTimeToFileTime(UInt16 wFatDate, UInt16 wFatTime, ref FileTime lpFileTime);
    [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
    private static extern bool FileTimeToSystemTime(ref FileTime lpFileTime, ref Systime lpSystemTime);
    [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
    private static extern bool FileTimeToDosDateTime(ref FileTime lpFileTime, ref UInt16 wFatDate, ref UInt16 wFatTime);
    [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
    private static extern bool SystemTimeToFileTime(ref Systime lpSystemTime, ref FileTime lpFileTime);
    public static DateTime FromMSDosDate(UInt16 toConvert)
    {
        FileTime fileTime = new FileTime();
        Systime systemTime = new Systime();
        DosDateTimeToFileTime(toConvert, 0, ref fileTime);
        FileTimeToSystemTime(ref fileTime, ref systemTime);
        return new DateTime(systemTime.Year, systemTime.Month, systemTime.Day, 0, 0, 0);
    }
    public static UInt16 ToMSDosDate(DateTime toConvert)
    {
        Systime systemTime = new Systime();
        FileTime fileTime = new FileTime();
        UInt16 fatDate = 0;
        UInt16 fatTime = 0;
        systemTime.Day = (UInt16)toConvert.Day;
        systemTime.Month = (UInt16)toConvert.Month;
        systemTime.Year = (UInt16)toConvert.Year;
        SystemTimeToFileTime(ref systemTime, ref fileTime);
        FileTimeToDosDateTime(ref fileTime, ref fatDate, ref fatTime);
        return fatDate;
    }
    [TestMethod]
    public void Test_MSDos_Date()
    {
        UInt16 testDate = 11021; // int value read from binary test file...
        DateTime expected = new DateTime(2001, 8, 13, 0, 0, 0);
        Assert.AreEqual(expected, Utils.FromMSDosDate(testDate));
        Assert.AreEqual(testDate, Utils.ToMSDosDate(expected));
    }
