    public class MyClass
    {
        public static string GetStuff()
        {
            return string.Empty;
        }
    }
    
    public class MyClassExtension : MyClass
    {
        public static string GetOtherStuff()
        {
           // also cannot use any non-public members of MyClass
            return string.Empty;
        }
    }
    MyClassExtension.GetStuff();
    MyClassExtension.GetOtherStuff();
