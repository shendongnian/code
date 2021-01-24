    public static class Extensions {
        public static void WriteSecure(this StreamWriter writer, SecureString sec) {
            int length = sec.Length;
            if (length == 0)
                return;
            IntPtr ptr = Marshal.SecureStringToBSTR(sec);
            try {
                // each char in that string is 2 bytes, not one (it's UTF-16 string)
                for (int i = 0; i < length * 2; i += 2) {
                    // so use ReadInt16 and convert resulting "short" to char
                    var ch = Convert.ToChar(Marshal.ReadInt16(ptr + i));
                    // write
                    writer.Write(ch);
                }
            }
            finally {
                // don't forget to zero memory
                Marshal.ZeroFreeBSTR(ptr);
            }
        }
    }
