    public class C {
        public List<int> Items { get; } = new List<int>();
    }
 
...
    //  This can't be assigning to Items, because it's read-only
    var c = new C { Items = { 0, 1, 2 } };
