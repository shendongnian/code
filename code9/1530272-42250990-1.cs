    public class ParentTreeClass<T> where T: ITree
    {
        public T Parent { get; set; }
        public IList<T> Children { get; set; }
        // Other stuff.
    }
    public interface ITree
    {
        IList<ITree> Children { get; set; }
        ITree Parent { get; set; }
    }
    public class ImportTree : ParentTreeClass<ITree>, ITree
    {
        // Some overrides.
    }
    public class ExportTree : ParentTreeClass<ITree>, ITree
    {
        // Some other overrides.
    }
