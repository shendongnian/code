    class DerivedLike
    {
        public static explicit operator Derived(DerivedLike a)
        {
            return new Derived() { IntProperty = a.IntProp};
        }
        public int IntProp { get; set; }
        public int CalculateSomethingElse()
        {
            return IntProp * 23;
        }
    }
