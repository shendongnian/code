    class JaggedArrayMarshaler : ICustomMarshaler
    {
        static ICustomMarshaler GetInstance(string cookie)
        {
            return new JaggedArrayMarshaler();
        }
        GCHandle[] handles;
        GCHandle buffer;
        Array[] array;
        public void CleanUpManagedData(object ManagedObj)
        {
        }
        public void CleanUpNativeData(IntPtr pNativeData)
        {
            buffer.Free();
            foreach (GCHandle handle in handles) handle.Free();
        }
        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }
        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            array = (Array[])ManagedObj;
            handles = new GCHandle[array.Length];
            for (int i = 0; i < array.Length; i++)
                handles[i] = GCHandle.Alloc(array[i], GCHandleType.Pinned);
            IntPtr[] pointers = new IntPtr[handles.Length];
            for (int i = 0; i < handles.Length; i++)
                pointers[i] = handles[i].AddrOfPinnedObject();
            buffer = GCHandle.Alloc(pointers, GCHandleType.Pinned);
            return buffer.AddrOfPinnedObject();
        }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return array;
        }
    }
