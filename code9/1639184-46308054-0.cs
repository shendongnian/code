    public interface IFoo
    {
        int getAll();
    }
    public class Foo : IFoo
    {
        public Foo()
        {
        }
        public int getAll() => 1;
    }
        
    public List<T> Method<T>() where T : IFoo, new()
    {
       var items = new List<T>();
       
       var foo = new T();
       items.Add(foo);
       return items;
    }
    var list = Method<Foo>();
