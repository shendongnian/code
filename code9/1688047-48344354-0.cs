    [StructLayout(LayoutKind.Explicit)]
    public struct NotBool
    {
        [FieldOffset(0)]
        public readonly bool Value;
        [FieldOffset(0)]
        private readonly int Int;
        public NotBool(int intValue)
        {
            Value = false;
            Int = intValue;
        }
    }
