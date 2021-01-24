    public class BaseClass { }
    public class DerivedClass: BaseClass { }
    public class GenericClass<T> where T : BaseClass
    {
        public string TypeOf = typeof(T).ToString();
    }
    public class GenericSuperClass<T> where T : BaseClass
    {
        public GenericClass<T> Sub = new GenericClass<T>();
    }
         
    static void Main(string[] args)
    {
        Console.WriteLine("1 - " + (new GenericClass<BaseClass>()).TypeOf);
        Console.WriteLine("2 - " + (new GenericClass<DerivedClass>()).TypeOf);
        Console.WriteLine("3 - " + (new GenericSuperClass<BaseClass>()).Sub.TypeOf);
        Console.WriteLine("4 - " + (new GenericSuperClass<DerivedClass>()).Sub.TypeOf);
        Console.ReadLine();
    }
