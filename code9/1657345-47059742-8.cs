    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct SDK_ALARM_INFO
    {
        [FieldOffset(0)]
        int nChannel;
        [FieldOffset(4)]
        int iEvent;  //refer to SDK_EventCodeType
        [FieldOffset(8)]
        int iStatus; // 0: start 1: stop
        [FieldOffset(12)]
        SDK_SYSTEM_TIME SysTime;
        [FieldOffset(12)]
        fixed int Time[8];
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SDK_SYSTEM_TIME
    {
        public int year;
        public int month;
        public int day;
        public int wday;
        public int hour;
        public int minute;
        public int second;
        public int isdst;
    }
