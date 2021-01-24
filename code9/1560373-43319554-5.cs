    public class TDeviceWrapper : IDisposable
    {
        // Fastcall not handled by C#
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void TIntEventFunc(int Status);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void TVoidEventFunc();
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public delegate void TResultEventFunc(string cmd, int code);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void TModeEventFunc(int mode, int reason);
        IntPtr ptr;
        [DllImport("TDevice.dll")]
        static extern IntPtr NewDevice();
        [DllImport("TDevice.dll")]
        static extern void DeleteDevice(IntPtr pWrapper);
        [DllImport("TDevice.dll")]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        static extern string GetPortName(IntPtr pWrapper);
        [DllImport("TDevice.dll")]
        static extern void Connect(IntPtr pWrapper);
        [DllImport("TDevice.dll")]
        static extern void SetStatus(IntPtr pWrapper, TIntEventFunc statusFunc);
        [DllImport("TDevice.dll")]
        static extern void SetResult(IntPtr pWrapper, TResultEventFunc resultFunc);
        // To prevent the GC from collecting the managed-tounmanaged thunks, we save the delegates
        TModeEventFunc modeFunc;
        TIntEventFunc statusFunc;
        TIntEventFunc sensorsFunc;
        TVoidEventFunc infoFunc;
        TResultEventFunc resultFunc;
        public void Init()
        {
            ptr = NewDevice();
        }
        public string PortName
        {
            get
            {
                return GetPortName(ptr);
            }
        }
        public void Connect()
        {
            Connect(ptr);
        }
        public void SetStatus(TIntEventFunc statusFunc)
        {
            this.statusFunc = statusFunc;
            SetStatus(ptr, statusFunc);
        }
        public void SetResult(TResultEventFunc resultFunc)
        {
            this.resultFunc = resultFunc;
            SetResult(ptr, resultFunc);
        }
        ~TDeviceWrapper()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (ptr != IntPtr.Zero)
            {
                DeleteDevice(ptr);
                ptr = IntPtr.Zero;
            }
            if (disposing)
            {
                modeFunc = null;
                statusFunc = null;
                sensorsFunc = null;
                infoFunc = null;
                resultFunc = null;
            }
        }
    }
