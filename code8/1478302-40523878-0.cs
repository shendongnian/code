    public class SCardWrapper
    {
        [DllImport("scard-com.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint scan();
    }
