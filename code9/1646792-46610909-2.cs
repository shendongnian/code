    public abstract class Base<T> where T: IAttributes
    {
        public abstract T Attributes{ get; set; }
    }
    
    public interface IAttributes
    {
        string GlobalId { get; set; }
    }
