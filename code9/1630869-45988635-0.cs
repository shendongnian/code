    public struct Topo { }  
    public class Foo
    {
        // Private list of types. This is actual storage of the data.
        // It is inialized to a new empty list by the constructor.
        private List<Topo> InnerItems { get; } = new List<Topo>();
        // Example on how to modify the list only through this class
        // Methods have access to `InnerList`
        public void Add(Topo item) { InnerItems.Add(item); }
        // Outside of the class only `Items` is exposed
        // This poperty casts the list as a readonly collection
        public IReadOnlyCollection<Topo> Items => InnerItems;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            foo.Add(new Topo());
            // foo.Items.Add() doesnt exist.
            foreach(var item in foo.Items)
            {
                Console.WriteLine(item);
            }
        }
    }
