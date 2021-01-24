    class NativeMethods
    {
        // EntryPoint must be provided since we are naming the alternate
        // version MFCreateDXGISurfaceBuffer2 to separate it from the original
        [DllImport("mfplat.dll", ExactSpelling = true, EntryPoint = "MFCreateDXGISurfaceBuffer")]
        public static extern HResult MFCreateDXGISurfaceBuffer2(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            IntPtr punkSurface,
            int uSubresourceIndex,
            [MarshalAs(UnmanagedType.Bool)] bool fBottomUpWhenLinear,
            out IMFMediaBuffer ppBuffer
        );
    }
