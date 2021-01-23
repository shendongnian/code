<!-- -->
    var bytes = Enumerable.Range(0, 20).Select(n => (byte)(n + 240)).ToArray();
    foreach (var b in bytes) Console.Write("{0,-4}", b);
    // Pin the managed memory
    GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    for (int i = 0; i < bytes.Length; i += 4)
    {
        // Copy the data
        My my = (My)Marshal.PtrToStructure<My>(handle.AddrOfPinnedObject() + i);
        my.Int += 10;
        // Copy back
        Marshal.StructureToPtr(my, handle.AddrOfPinnedObject() + i, true);
    }
    // Unpin
    handle.Free();
    foreach (var b in bytes) Console.Write("{0,-4}", b);
