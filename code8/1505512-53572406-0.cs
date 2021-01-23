    [ComImport]
    [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    unsafe interface IMemoryBufferByteAccess
    {
        void GetBuffer(out byte* buffer, out uint capacity);
    }
    private static void Graph_QuantumStarted(AudioGraph sender, object args)
    {
        AudioFrame frame = frameOutputNode.GetFrame();
        using (AudioBuffer buffer = frame.LockBuffer(AudioBufferAccessMode.Write))
        using (IMemoryBufferReference reference = buffer.CreateReference())
        {
            //Run Fourier and Adjust here
        }
    }
