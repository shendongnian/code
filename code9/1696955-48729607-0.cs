        [DllImport("msvcr.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _fpreset();
        public static void Run()
        {
           // Other code
            _fpreset(); // Reinitialises the floating-point package
        }
