    public abstract class Base<TAttributes> where TAttributes : IAttributes
    {
        public abstract TAttributes Attributes{ get; set; }
    }
    
    public interface IAttributes
    {
        string GlobalId { get; set; }
    }
