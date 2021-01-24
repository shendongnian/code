        [StructLayout(LayoutKind.Explicit, Pack = 2)]
    public struct IntListO
    {
        //public IntListO()
        //{
        //    Handle = IntPtr.Zero;
        //    FCount = 0;
        //    SizeOfItem = sizeOfItem;
        //    FCapacity = 0;
        //}
        private static int ItemSize = 4;//size of integer
        [FieldOffset(0)]
        private int FCount;
        [FieldOffset(sizeof(int))]
        private int FCapacity;
        [FieldOffset(sizeof(int) * 2)]
        private IntPtr Handle;
    }
