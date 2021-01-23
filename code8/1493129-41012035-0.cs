    public class A
    {
       public static A LastInstance { get; private set; }
       ...
    }
    public class B : A
    {
       public static new B LastInstance { get; private set; }
       ...
    }
