    [ComVisible(true)]
    [Guid("7FE927E1-79D3-42DB-BE7F-B830C7CD32AE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IImageProvider
    {
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
        byte[] GetImage(int foo);
        IntPtr GetImageAsUnmanaged(int foo, out int cbBuff);
        void GetImageAsUnmanagedPreallocated(int foo, ref int cbBuff, IntPtr pBuff);
    }
