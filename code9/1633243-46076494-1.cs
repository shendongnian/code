    public partial class MyClass<T> where T : MyClass<T>
    {
        public void SomeMethod() { Console.WriteLine("some method"); }
    }
    public partial class MyClass<T> where T : MyClass<T>
    {
        public void SomeOtherMethod() { Console.WriteLine("some other method"); }
    }
