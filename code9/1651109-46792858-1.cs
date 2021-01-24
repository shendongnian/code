    public interface IElementA<T>
    {
        List<T> Child { get; }
    }
    public interface IElementB
    {
        string Name { get; }
    }
    public class ElementB : IElementA<ElementB>, IElementB
    {
        protected List<ElementB> m_Child = new List<ElementB>();
        public List<ElementB> Child { get { return m_Child; } }
        public string Name
        {
            get { return "element B"; }
        }
    }
