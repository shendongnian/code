            static byte[] getBytes<T>(T str) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            int Pack = str.GetType().StructLayoutAttribute.Pack;
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            arr = RemovePadding<T>(arr.ToList(), str, str.GetType().StructLayoutAttribute.Pack);
            return arr;
        }
        static byte[] RemovePadding<T>(List<byte> buffer, T str, int Pack)
        {
            int largestsize = 0;
            int index = 0;
            int RowOfMemory = 0;
            //Get all fields 
            var fields = str.GetType().GetFields();
            //After MSDN
            //The alignment of the type is the size of its largest element (1, 2, 4, 8, etc., bytes) or the specified packing size, whichever is smaller.
            foreach (var item in fields)
            {
                if (Marshal.SizeOf(item.FieldType) > largestsize)
                    largestsize = Marshal.SizeOf(item.FieldType);
            }
            if (largestsize < Pack) Pack = largestsize;
            //Find and remove padding from all memory rows 
            foreach (var item in fields)
            {
                int size = Marshal.SizeOf(item.FieldType);
                if (RowOfMemory != 0 && (RowOfMemory + size) > Pack)
                {
                    int paddingsize = Math.Abs(Pack - RowOfMemory);
                    buffer.RemoveRange(index, paddingsize);
                    RowOfMemory = size % Pack;
                }
                else if ((RowOfMemory + size) < Pack)
                {
                    RowOfMemory += size;
                }
                else if ((RowOfMemory + size) == Pack)
                {
                    RowOfMemory = 0;
                }
                index += size;
            }
            if (RowOfMemory != 0)
            {
                int paddingsize = Math.Abs(Pack - RowOfMemory);
                buffer.RemoveRange(index, paddingsize);
            }
            return buffer.ToArray();
        }
