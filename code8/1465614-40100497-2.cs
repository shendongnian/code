     public interface IBaseClass
    {
      int Value { get; set; }
    }
    
    ublic class BaseClass:IBaseClass
    {
        public int Value { get; set; }
    }
    
    public class SubClassA : BaseClass,IBaseClass
    {
        public bool SomeBoolValue { get; set; }
    }
    
    public class SubClassB : BaseClass,IBaseClass
    {
        public decimal SomeDecimalValue { get; set; }
    }
