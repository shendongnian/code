    public bool ReadBool(int Address)
    {
        IntPtr intPtr = IntPtr.Zero;
        byte[] bArray = new byte[1];
        Process_MemoryReaderWriter.ReadProcessMemory((IntPtr)this.Handle, (IntPtr)Address, bArray, 1, out intPtr);
        return BitConverter.ToBoolean(bArray, 0);
    }
