        static void Main(string[] args)
        {
            //Creating test data
            List<byte> data = new List<byte>();
            data.Add(123);
            data.AddRange(BitConverter.GetBytes((int)123456));
            //Converting test data to Struct
            Marker m = StructFromBytes<Marker>(data.ToArray());
            //Check if it works
            Console.WriteLine(m.label); //Prints 123
            Console.WriteLine(m.count); //Prints 123456
        }
        private static T StructFromBytes<T>(byte[] bytes)
        {
            int structSize = Marshal.SizeOf(typeof(T));
            byte[] structBytes = new byte[structSize];
            Array.Copy(bytes, 0, structBytes, 0, structSize);
            GCHandle handle = GCHandle.Alloc(structBytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return theStructure;
        }
