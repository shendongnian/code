    public interface INestedList
    {
        List<object> InnerList { get; }
    }
    public class ContainsNestedList : INestedList
    {
        public List<object> InnerList { get; }
        public string Name { get; }
        public ContainsNestedList(string name, List<object> innerList)
        {
            Name = name;
            InnerList = innerList;
        }
        public override string ToString()
        {
            return Name;
        }
    }
