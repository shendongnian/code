    public class BaseClass
    {
        public DateTime DateCreated { get; protected set; } //only protected because that's what I need...
        public BaseClass()
        {
            DateCreated = DateTime.Now;
        }
    }
    
    public class DerivedClas : BaseClass
    {
        public DerivedClass 
            : base()
        {
        }
    }
