    [StructLayout(LayoutKind.Sequential)]
    public struct TCommandBuffer
    {
        public int Command;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public TCommandParam[] Param;
        public int ReturnValue;
        public TCommandBuffer(int tsize, int cmd, int ret)
        {
            Param = new TCommandParam[tsize];
            Command = cmd;
            ReturnValue = ret;
        }
    }
