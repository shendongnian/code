        [DllImport(@"TELCompress.dll", EntryPoint = "TELMonDecode", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int TELMonDecode(ref bool a, ref bool b, byte[] ab, ref String pDestBuf, int j, int byteCount);
    ... //Some code here
    //Call to the C++ function 
     int returnval = TELMonDecode(ref a, ref b, bytes, ref receiveStr, k, bytesRec);
