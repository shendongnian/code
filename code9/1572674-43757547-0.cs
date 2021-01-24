    public abstract class MyBaseClass
    {
        public static string SomeProperty { get; set; }
    }
    //Module 1
    public class MyClassOne : MyBaseClass
    {
        public static string MyFunction()
        {
            return SomeProperty + "MyClassOne";
        }
    }
    //Module 2
    public class MyClassTwo : MyBaseClass
    {
        public static string MyFunction()
        {
            return SomeProperty + "MyClassTwo";
        }
    }
