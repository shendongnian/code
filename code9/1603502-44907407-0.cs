    [StructLayout(LayoutKind.Explicit)]
    struct MyPackedLong {
        [FieldOffset(0)] uint item1;    // 24-bit field
        [FieldOffset(3)] uint item2;    // 24-bit field
        [FieldOffset(6)] ushort item3;  // 16-bit field
        
        public uint Item1 {
            get { return item1 & 0xffffff; }
            set { item1 = (item1 & 0xff000000) | value; }
        }
        public uint Item2 {
            get { return item2 & 0xffffff; }
            set { item2 = (item2 & 0xff000000) | value; }
        }
        public ushort Item3 {
            get { return item3; }
            set { item3 = value; }
        }
    }
