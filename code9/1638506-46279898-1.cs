    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class NewStuff
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public StringBuilder name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4*16)]
        public float[,] calibrate;
        [MarshalAs(UnmanagedType.R4)]
        public float DMTI;
        [MarshalAs(UnmanagedType.R4)]
        public float DMTII;
        // Etc
    }
