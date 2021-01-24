    public class SomeClass
    {
        public static int someValue;
        public virtual int GetValue() => someValue;
        public Some_Logic_That_Uses_somevalue()
        {
            // Complex large method getting 'someValue' through GetValue()
        }
    }
    public class ClassA : SomeClass
    {
        public static int someValueForA;
        public override int GetValue() => someValueForA;
    }
    public class ClassB : SomeClass
    {
        public static int someValueForB;
        public override int GetValue() => someValueForB;
    }
}
