    public class SomeClass
    {
        public static int someValue;
        public virtual int someValueProp
        {
            get { return someValue; }
            set { someValue = value; }
        }
    
        public void Some_Logic_That_Uses_somevalue()
        {
            // Complex large method using 'someValueProp'
        }
    }
    public class ClassB : SomeClass
    {
        public static int anotherValue;
        public override int someValueProp
        {
            get { return anotherValue; }
            set { anotherValue = value; }
        }
    }
