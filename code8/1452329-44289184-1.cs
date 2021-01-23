    using System;
    using System.Runtime.InteropServices;
    public static class SecureStringExtensions 
    {
        public static T Decrypt<T>(this SecureString ss, Func<string, T> handler) 
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            var ptr = Marshal.SecureStringToBSTR(ss);
            try {
                return handler(Marshal.PtrToStringBSTR(ptr));
            } finally {
                Marshal.ZeroFreeBSTR(ptr);
            }
        }
    }
