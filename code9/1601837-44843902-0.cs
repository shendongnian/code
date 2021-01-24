    public interface ISet
    {
        string Value { set; }
    }
    public interface IGet
    {
        string Value { get; }
    }
    
    public class GetSetClass : IGet, ISet
    {
        public string Value { get; set; }
        string IGet.Value // Explicitly implementation
        {
            get { return Value; }
        }
        string ISet.Value // Explicitly implementation
        {
            set { Value = value; }
        }
    }
