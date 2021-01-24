    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime {
        [MarshalAs(UnmanagedType.U2)] public short Year;
        [MarshalAs(UnmanagedType.U2)] public short Month;
        [MarshalAs(UnmanagedType.U2)] public short DayOfWeek;
        [MarshalAs(UnmanagedType.U2)] public short Day;
        [MarshalAs(UnmanagedType.U2)] public short Hour;
        [MarshalAs(UnmanagedType.U2)] public short Minute;
        [MarshalAs(UnmanagedType.U2)] public short Second;
        [MarshalAs(UnmanagedType.U2)] public short Milliseconds;
    
        public SystemTime(DateTime dt) {
            dt = dt.ToUniversalTime();  // SetSystemTime expects the SYSTEMTIME in UTC
            Year = (short)dt.Year;
            Month = (short)dt.Month;
            DayOfWeek = (short)dt.DayOfWeek;
            Day = (short)dt.Day;
            Hour = (short)dt.Hour;
            Minute = (short)dt.Minute;
            Second = (short)dt.Second;
            Milliseconds = (short)dt.Millisecond;
        }
    }
    
    public struct JobInfo2 {
        public uint JobID;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string PrinterName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string ServerName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string UserName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string DocumentName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string NotifyName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string DataType;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string PrintProcessor;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string Parameters;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string DriverName;
        public IntPtr DevMode;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string strStatus;
        public IntPtr SecurityDescriptor;
        public uint Status;
        public uint Priority;
        public uint Position;
        public uint StartTime;
        public uint UntilTime;
        public uint TotalPages;
        public uint Size;
        public SystemTime Submitted;
        public uint Time;
        public uint PagesPrinted;
    }
