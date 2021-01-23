    [StructLayout(LayoutKind.Explicit, Size = 5)]
        public struct Marker
        {
            [FieldOffset(0)]
            public byte label;
            [FieldOffset(1)]
            public int count;
    
            [FieldOffset(1)]
            private byte count_0;
            [FieldOffset(2)]
            private byte count_1;
            [FieldOffset(3)]
            private byte count_2;
            [FieldOffset(4)]
            private byte count_3;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<byte> data = new List<byte>();
                data.Add(123);
                data.AddRange(BitConverter.GetBytes((int)123456));
    
                using (MemoryStream stream = new MemoryStream(data.ToArray()))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Marker m = FromBytes<Marker>(reader);
                    Console.WriteLine(m.label);
                    Console.WriteLine(m.count);
                }
            }
    
            private static T FromBytes<T>(BinaryReader reader)
            {
    
                // Read in a byte array
                byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
    
                // Pin the managed memory while, copy it out the data, then unpin it
                GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();
    
                return theStructure;
            }
        }
