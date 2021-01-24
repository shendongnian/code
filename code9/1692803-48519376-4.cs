    public enum MyEnum
    {
        Type1, Type2
    }
    public abstract class MyBaseClass
    {
        public abstract MyEnum GetMyType();
    }
    public class MySubClass1 : MyBaseClass
    {
        public override MyEnum GetMyType()
        {
            // implementation
        }
    }
    public class MySubClass2 : MyBaseClass
    {
        public override MyEnum GetMyType()
        {
            // implementation
        }
    }
