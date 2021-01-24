    public class BaseClass
    {
        public virtual string Str { get; set; } = "base";
    }
    public class DerivedClass : BaseClass
    {
        public override string Str { get; set; } = "derived";
    }
    public class TestingClass
    {
        public TestingClass()
        {
            AnotherClass a = new AnotherClass();
            Console.WriteLine(a.SomeMethod<GenericObjClass<BaseClass>, BaseClass>(new GenericObjClass<BaseClass>(){ Query = new BaseClass()}));
            Console.WriteLine(a.SomeMethod<GenericObjClass<DerivedClass>, DerivedClass>(new GenericObjClass<DerivedClass>() { Query = new DerivedClass() }));
            Console.WriteLine(a.SomeMethod(new GenericObjClass<BaseClass>() { Query = new BaseClass() }));
            Console.WriteLine(a.SomeMethod(new GenericObjClass<BaseClass>() { Query = new DerivedClass() }));
        }
    }
    public class AnotherClass
    {
        public string SomeMethod<T>(T obj) where T : IGenericObj<BaseClass>
        {
            return obj.Query.Str;
        }
        public string SomeMethod<T, T2>(T obj) where T : IGenericObj<T2> where T2 : BaseClass
        {
            return obj.Query.Str;
        }
    }
    public class GenericObjClass<T> : IGenericObj<T> where T : BaseClass
    {
        public T Query { get; set; }
    }
    public interface IGenericObj<T> where T : BaseClass
    {
        T Query { get; set; }
    }
