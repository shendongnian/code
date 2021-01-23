    class SomeType
    {
        int mVariable;
        public SomeType(int size)
        {
            mVariable = size;
        }
    }
    static void Main(string[] args)
    {
        Type someType = typeof(SomeType);
        SomeType instance = (SomeType)FormatterServices.GetUninitializedObject(someType);
        // instance.mVariable = 0;
    }
