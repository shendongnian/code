    /// <summary>
    /// This class changes floating-point precision to 64 bit
    /// </summary>
    internal class FloatingPoint64BitPrecision : IDisposable
    {
        private readonly bool _resetRequired;
        public FloatingPoint64BitPrecision()
        {
            int fpFlags;
            var errno = SafeNativeMethods._controlfp_s(out fpFlags, 0, 0);
            if (errno != 0)
            {
                throw new Win32Exception(
                    errno, "Unable to retrieve floating-point control flag.");
            }
            if ((fpFlags & SafeNativeMethods._MCW_PC) != SafeNativeMethods._PC_64)
            {
                Trace.WriteLine("Change floating-point precision to 64 bit");
                errno = SafeNativeMethods._controlfp_s(
                    out fpFlags, SafeNativeMethods._PC_64, SafeNativeMethods._MCW_PC);
                if (errno != 0)
                {
                    throw new Win32Exception(
                        errno, "Unable to change floating-point precision to 64 bit.");
                }
                _resetRequired = true;
            }
        }
        public void Dispose()
        {
            if (_resetRequired)
            {
                Trace.WriteLine("Resetting floating-point precision to default");
                SafeNativeMethods._fpreset();
            }
        }
    }
    internal static class SafeNativeMethods
    {
        [DllImport("msvcr120.dll")]
        public static extern void _fpreset();
        [DllImport("msvcr120.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _controlfp_s(
            out int currentControl, int newControl, int mask);
        public static int _CW_DEFAULT = 
            (_RC_NEAR | _PC_53 | _EM_INVALID | _EM_ZERODIVIDE | _EM_OVERFLOW 
            | _EM_UNDERFLOW | _EM_INEXACT | _EM_DENORMAL);
        public const int _MCW_EM = 0x0008001f;          // interrupt Exception Masks 
        public const int _EM_INEXACT = 0x00000001;      //   inexact (precision) 
        public const int _EM_UNDERFLOW = 0x00000002;    //   underflow 
        public const int _EM_OVERFLOW = 0x00000004;     //   overflow 
        public const int _EM_ZERODIVIDE = 0x00000008;   //   zero divide 
        public const int _EM_INVALID = 0x00000010;      //   invalid 
        public const int _EM_DENORMAL = 0x00080000;     // denormal exception mask 
                                                        // (_control87 only) 
        public const int _MCW_RC = 0x00000300;          // Rounding Control 
        public const int _RC_NEAR = 0x00000000;         //   near 
        public const int _RC_DOWN = 0x00000100;         //   down 
        public const int _RC_UP = 0x00000200;           //   up 
        public const int _RC_CHOP = 0x00000300;         //   chop 
        public const int _MCW_PC = 0x00030000;          // Precision Control 
        public const int _PC_64 = 0x00000000;           //    64 bits 
        public const int _PC_53 = 0x00010000;           //    53 bits 
        public const int _PC_24 = 0x00020000;           //    24 bits 
        public const int _MCW_IC = 0x00040000;          // Infinity Control 
        public const int _IC_AFFINE = 0x00040000;       //   affine 
        public const int _IC_PROJECTIVE = 0x00000000;   //   projective 
    }
