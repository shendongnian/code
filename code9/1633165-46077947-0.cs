    void BlitFromByteArrayToArray(byte[] src, T[] dst)
    {
        Debug.Assert(src.Length == dst.Length * Marshal.SizeOf(typeof(T)));
        GCHandle handle = GCHandle.Alloc(dst, GCHandleType.Pinned);
        try
        {
            Marshal.Copy(src, 0, handle.AddrOfPinnedObject(), src.Length);
        }
        finally
        {
            handle.Free();
        }
    }
