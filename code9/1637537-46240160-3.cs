        public static object ReadStruct(byte[] data, Type type)
        {
            var pinnedPacket = GCHandle.Alloc(data, GCHandleType.Pinned);
            var obj = Marshal.PtrToStructure(pinnedPacket.AddrOfPinnedObject(), type); 
            pinnedPacket.Free();
            return obj;
        }
