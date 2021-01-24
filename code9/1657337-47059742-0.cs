    [StructLayout(LayoutKind.Sequential)]
    public struct SDK_ALARM_INFO
    {
        int nChannel;
        int iEvent;  //refer to SDK_EventCodeType
        int iStatus; // 0: start 1: stop
        SDK_SYSTEM_TIME SysTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SDK_SYSTEM_TIME
    {
        public ulong Time;
    }
