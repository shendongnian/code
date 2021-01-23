    public struct PGMODENV
    {
        public int lMajor; // major version of kernel
        public int lMinor; // minor version of kernel
        public int lRelease; // release version of kernel
        public int lResultSize; // sResult buffer size
        //The original C++ function pointer contained an unconverted modifier:
        //ORIGINAL LINE: int(__stdcall *lPGSM_ExecuteKernel)(struct _modenv_ *PGEnv, sbyte *sCommand, sbyte *sResult, int lLength);
        public delegate int lPGSM_ExecuteKernelDelegate(PGMODENV PGEnv, ref string sCommand, ref string sResult, int lLength);
        public lPGSM_ExecuteKernelDelegate lPGSM_ExecuteKernel;
        //The original C++ function pointer contained an unconverted modifier:
        //ORIGINAL LINE: int(__stdcall *lPGSM_ExecuteCommand)(struct _modenv_ *PGEnv, sbyte *sCommand, sbyte *sResult, int lLength);
        public delegate int lPGSM_ExecuteCommandDelegate(PGMODENV PGEnv, ref string sCommand, ref string sResult, int lLength);
        public lPGSM_ExecuteCommandDelegate lPGSM_ExecuteCommand;
    }
