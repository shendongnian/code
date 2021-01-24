    public partial class MyClass<T> where T : MyOtherClass
    {
        public void SomeMethod() { Console.WriteLine("some method"); }
    }
    public partial class MyClass<T> where T : MyOtherClass
    {
        public void SomeOtherMethod() { Console.WriteLine("some other method"); }
    }
    public class MyOtherClass
    {
    }
