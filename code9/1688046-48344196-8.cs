    [StructLayout(LayoutKind.Explicit)]
    struct Evil
    {
        public Evil(int value)
        {
            Boolean = false;
            Int32 = value;
        }
        [FieldOffset(0)]
        public bool Boolean;
        [FieldOffset(0)]
        public int Int32;
    }
    static bool GetMyWeirdBool()
    {
        var val = new Evil(42);
        return val.Boolean;
    }
