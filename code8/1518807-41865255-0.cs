    internal static byte[] SerializeArray<T>(T[] array) where T : struct
        {
        int unmananagedSize = Marshal.SizeOf(typeof(T));
        int numBytes = array.Length * unmananagedSize;
        byte[] bytes = new byte[numBytes];
        using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("fred", bytes.Length))
            {
            using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(0, bytes.Length, MemoryMappedFileAccess.ReadWrite))
                {
                accessor.WriteArray<T>(0, array, 0, array.Length);
                accessor.ReadArray<byte>(0, bytes, 0, bytes.Length);
                }
            }
        return bytes;
        }
    internal static T[] DeSerializeArray<T>(byte[] bytes) where T : struct
        {
        int unmananagedSize = Marshal.SizeOf(typeof(T));
        int numItems = bytes.Length / unmananagedSize;
        T[] newArray = new T[numItems];
        using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("fred", bytes.Length))
            {
            using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(0, bytes.Length, MemoryMappedFileAccess.ReadWrite))
                {
                accessor.WriteArray<byte>(0, bytes, 0, bytes.Length);
                accessor.ReadArray<T>(0, newArray, 0, newArray.Length);
                }
            }
        return newArray;
        }
