    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [Guid("D133B928-A98B-4006-8B00-4AA09BD042E7")]
    [ProgId("CSByteArrayServer.ImageProvider")]
    public class ImageProvider : IImageProvider
    {
        private const int E_INVALIDARG = unchecked((int)0x80070057);
        RNGCryptoServiceProvider crng = new RNGCryptoServiceProvider();
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
        public byte[] GetImage(int foo)
        {
            return GetBytes();
        }
        private byte[] GetBytes()
        {
            byte[] data = new byte[500];
            crng.GetBytes(data);
            return data;
        }
        public IntPtr GetImageAsUnmanaged(int foo, out int cbBuff)
        {
            var data = GetBytes();
            var result = Marshal.AllocCoTaskMem(data.Length);
            Marshal.Copy(data, 0, result, data.Length);
            cbBuff = data.Length;
            return result;
        }
        public void GetImageAsUnmanagedPreallocated(int foo, ref int cbBuff, IntPtr pBuff)
        {
            var data = GetBytes();
            if (cbBuff < data.Length)
            {
                cbBuff = data.Length;
                throw Marshal.GetExceptionForHR(E_INVALIDARG);
            }
            cbBuff = data.Length;
            Marshal.Copy(data, 0, pBuff, data.Length);
        }
    }
