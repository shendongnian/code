    [DllImport("coredll.dll")]
    public static extern void GetSystemInfo(out SystemInfo info);
    public enum ProcessorArchitecture
    {
        Intel = 0,
        Mips = 1,
        Shx = 4,
        Arm = 5,
        Unknown = 0xFFFF,
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemInfo
    {
        public ProcessorArchitecture ProcessorArchitecture;
        public uint PageSize;
        public IntPtr MinimumApplicationAddress;
        public IntPtr MaximumApplicationAddress;
        public IntPtr ActiveProcessorMask;
        public uint NumberOfProcessors;
        public uint ProcessorType;
        public uint AllocationGranularity;
        public ushort ProcessorLevel;
        public ushort ProcessorRevision;
    }
