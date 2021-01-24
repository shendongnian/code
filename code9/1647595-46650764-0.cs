    public struct Test
    {
        public int a;
    }
    public ref Test GetValueByRef()
    {
        var test = new Test();
        return ref test;
    }
