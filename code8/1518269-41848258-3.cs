    public IntPtr GetImage() {
        DataRow dr = ImgBlobDT.Rows[0];
        byte[] imgBytes = (byte[])dr["ImgBinary"];
        // Initialize unmanaged memory to hold the array.
        int size = Marshal.SizeOf(imgBytes [0]) * imgBytes .Length;
        IntPtr pnt = Marshal.AllocHGlobal(size);
        // Copy the array to unmanaged memory.
        Marshal.Copy(imgBytes , 0, pnt, imgBytes .Length);
        // your method will return a unmanaged pointer instead of byte[]
        return pnt;
    }
