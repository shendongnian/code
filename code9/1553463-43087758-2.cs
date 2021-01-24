    private static IntPtr GenerateKey(IntPtr hProv, byte[] keyData)
    {
        var hHash = IntPtr.Zero;
        try
        {
            bool check = Win32.CryptCreateHash(hProv, Win32.CALG_MD5, IntPtr.Zero, 0, out hHash);
            if (!check)
            {
                throw new Win32Exception();
            }
            check = Win32.CryptHashData(hHash, keyData, keyData.Length, 0);
            if (!check)
            {
                throw new Win32Exception();
            }
            IntPtr hKey;
            check = Win32.CryptDeriveKey(hProv, Win32.CALG_3DES, hHash, Win32.CRYPT_EXPORTABLE, out hKey);
            if (!check)
            {
                throw new Win32Exception();
            }
            return hKey;
        }
        finally
        {
            if (hHash != IntPtr.Zero)
            {
                Win32.CryptDestroyHash(hHash);
            }
        }
    }
    public static byte[] Encrypt(byte[] plainText)
    {
        var keyData = Encoding.ASCII.GetBytes("{2B9B4443-74CE-42A8-8803-076B136B5967}");
        IntPtr hCryptProv = IntPtr.Zero;
        IntPtr hKey = IntPtr.Zero;
        try
        {
            bool check = Win32.CryptAcquireContext(out hCryptProv, null, null, Win32.PROV_RSA_FULL, Win32.CRYPT_VERIFYCONTEXT | Win32.CRYPT_MACHINE_KEYSET);
            if (!check)
            {
                check = Win32.CryptAcquireContext(out hCryptProv, null, null, Win32.PROV_RSA_FULL, Win32.CRYPT_NEWKEYSET | Win32.CRYPT_VERIFYCONTEXT | Win32.CRYPT_MACHINE_KEYSET);
                if (!check)
                {
                    throw new Win32Exception();
                }
            }
            hKey = GenerateKey(hCryptProv, keyData);
            //byte[] key = ExportSymmetricKey(hCryptProv, hKey);
            //Debug.WriteLine(BitConverter.ToString(key));
            var size = plainText.Length;
            check = Win32.CryptEncrypt(hKey, IntPtr.Zero, 1, 0, null, ref size, 0);
            if (!check)
            {
                throw new Win32Exception();
            }
            var cypherText = new byte[size];
            Array.Copy(plainText, cypherText, plainText.Length);
            size = plainText.Length;
            check = Win32.CryptEncrypt(hKey, IntPtr.Zero, 1, 0, cypherText, ref size, cypherText.Length);
            if (!check)
            {
                throw new Win32Exception();
            }
            return cypherText;
        }
        finally
        {
            if (hKey != IntPtr.Zero)
            {
                Win32.CryptDestroyKey(hKey);
            }
            if (hCryptProv != IntPtr.Zero)
            {
                Win32.CryptReleaseContext(hCryptProv, 0);
            }
        }
    }
    // Based on https://books.google.it/books?id=aL3P3eJdiREC&pg=PT271&lpg=PT271&dq=PROV_RSA_FULL+CryptEncrypt&source=bl&ots=STsuConTHr&sig=W-BWwch8aZ-RqFb8N67rMHTrqYc&hl=it&sa=X&ved=0ahUKEwit2qKnlfvSAhWCtRQKHbL9BbQQ6AEIQzAF#v=onepage&q=PROV_RSA_FULL%20CryptEncrypt&f=false
    // Page 248
    private static byte[] ExportSymmetricKey(IntPtr hProv, IntPtr hKey)
    {
        IntPtr hExpKey = IntPtr.Zero;
        try
        {
            bool check = Win32.CryptGenKey(hProv, 1 /* AT_KEYEXCHANGE */, 1024 << 16, out hExpKey);
            if (!check)
            {
                throw new Win32Exception();
            }
            int size = 0;
            check = Win32.CryptExportKey(hKey, hExpKey, 1 /* SIMPLEBLOB */, 0, null, ref size);
            if (!check)
            {
                throw new Win32Exception();
            }
            var bytes = new byte[size];
            check = Win32.CryptExportKey(hKey, hExpKey, 1 /* SIMPLEBLOB */, 0, bytes, ref size);
            if (!check)
            {
                throw new Win32Exception();
            }
            // The next lines could be optimized by using a CryptDecrypt 
            // that accepts a IntPtr and adding directly 12 to the ref bytes
            // instead of copying around the byte array
            // 12 == sizeof(BLOBHEADER) + sizeof(ALG_ID)
            var bytes2 = new byte[size - 12];
            Array.Copy(bytes, 12, bytes2, 0, bytes2.Length);
            bytes = bytes2;
            bytes2 = null;
            check = Win32.CryptDecrypt(hExpKey, IntPtr.Zero, true, 0, bytes, ref size);
            if (!check)
            {
                throw new Win32Exception();
            }
            Array.Resize(ref bytes, size);
            return bytes;
        }
        finally
        {
            if (hExpKey != IntPtr.Zero)
            {
                Win32.CryptDestroyKey(hExpKey);
            }
        }
    }
    /// <summary>
    /// WinAPI Imports
    /// </summary>
    internal class Win32
    {
        public const uint PROV_RSA_FULL = 1;
        public const uint NTE_BAD_KEYSET = 0x80090016;
        public const uint CRYPT_NEWKEYSET = 0x00000008;
        public const uint CRYPT_VERIFYCONTEXT = 0xF0000000;
        public const uint CRYPT_MACHINE_KEYSET = 0x00000020;
        public const uint CRYPT_EXPORTABLE = 1;
        public const uint ALG_CLASS_HASH = (4 << 13);
        public const uint ALG_SID_MD5 = 3;
        public const uint CALG_MD5 = (ALG_CLASS_HASH | ALG_SID_MD5);
        public const uint ALG_CLASS_DATA_ENCRYPT = (3 << 13);
        public const uint ALG_TYPE_BLOCK = (3 << 9);
        public const uint ALG_SID_3DES = 3;
        public const uint CALG_3DES = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_3DES);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CryptAcquireContext(out IntPtr hProv, string pszContainer, string pszProvider, uint dwProvType, uint dwFlags);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptReleaseContext(IntPtr hProv, uint dwFlags);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptDestroyKey(IntPtr hKey);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptCreateHash(IntPtr hProv, uint Algid, IntPtr hKey, uint dwFlags, out IntPtr hHash);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptHashData(IntPtr hHash, [In, Out] byte[] pbData, int dwDataLen, uint dwSize);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptDestroyHash(IntPtr hHash);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptDeriveKey(IntPtr hProv, uint Algid, IntPtr hHash, uint dwFlags, out IntPtr hKey);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGenKey(IntPtr hProv, uint Algid, uint dwFlags, out IntPtr hKey);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptEncrypt(IntPtr hKey, IntPtr hHash, int Final, uint dwFlags, [In, Out] byte[] pbData, ref int pdwDataLen, int dwBufLen);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptExportKey(IntPtr hKey, IntPtr hExpKey, uint dwBlobType, uint dwFlags, [Out] byte[] pbData, ref int pdwDataLen);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGetKeyParam(IntPtr hKey, uint dwParam, [Out] byte[] pbData, ref int pdwDataLen, uint dwFlags);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptDecrypt(IntPtr hKey, IntPtr hHash, bool final, uint dwFlags, [In, Out] byte[] pbData, ref int pdwDataLen);
    }
