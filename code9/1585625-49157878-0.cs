    namespace Examples
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo<IHasName> nameList = new Foo<IHasName>(new List<IHasName>()
                {
                    new ObjectWithName("banana"),
                    new ObjectWithName("apple")
                });
    
                Foo<IHasId> idList = new Foo<IHasId>(new List<IHasId>()
                {
                    new ObjectWithId(1),
                    new ObjectWithId(2),
                    new ObjectWithId(3)
                });
    
                var obj1 = nameList.GetByName("banana");
                var obj2 = idList.GetById(2);
            }
        }
    
        public class ObjectWithName : IHasName
        {
            public string Name { get; }
            public ObjectWithName(string name)
            {
                Name = name;
            }
        }
    
        public class ObjectWithId : IHasId
        {
            public int Id { get; }
            public ObjectWithId(int id)
            {
                Id = id;
            }
        }
    
        public interface IHasName
        {
            string Name { get; }
        }
    
        public interface IHasId
        {
            int Id { get; }
        }
    
        public class Foo<T> : IEnumerable<T>
        {
            private IList<T> children;
    
            public Foo(IList<T> collection)
            {
                children = collection;
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return children.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return children.GetEnumerator();
            }
        }
    
        public static class FooExtensions
        {
            public static IHasId GetById(this Foo<IHasId> foo, int id)
            {
                return foo.FirstOrDefault(c => c.Id == id);
            }
    
            public static IHasName GetByName(this Foo<IHasName> foo, string name)
            {
                return foo.FirstOrDefault(c => c.Name == name);
            }
        }
    }
