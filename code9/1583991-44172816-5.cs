    // This will flatten it into a single object, sorted by one field and the the other. Since this is Linq, it will create these new flattened objects each time you iterate through the IEnumerable.
    public IEnumerable<FlattenedA> GetSortedFlattened(IEnumerable<A> collection)
    {
        var flattened = collection.SelectMany(a => a.Children.Select(ca => new FlattenedA() { Name = a.Name, SubName = ca.Name }));
        var sorted = flattened.OrderBy(f => f.Name).ThenBy(f => f.SubName);
        return sorted;
    }
    // This will return objects of A, where the child enumerable has been replaced with an OrderBy. Again this will return new objects each time you iterate through. Only when you iterate through the children will they be sorted.
    public IEnumerable<A> GetSortedNonFlattened(IEnumerable<A> collection)
    {
        var withSortedChildren = collection.Select(a => new A() { Name = a.Name, Children = a.Children.OrderBy(ca => ca.Name) });
        var sorted = withSortedChildren.OrderBy(a => a.Name);
        return sorted;
    }
    public class FlattenedA
    {
        public string Name { get;set }
        public string SubName { get; set; }
    }
    public class A
    {
        public string Name { get; set; }
        public IEnumerable<B> Children { get; set; }
    }
