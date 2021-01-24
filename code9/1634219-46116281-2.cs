    public interface IMyInterface
    {
        String Name { get; }
    }
    public class BaseType : IMyInterface
    {
        public virtual String Name
        {
            get { return "Base Name"; }
        }
    }
    public class DerivedType : BaseType
    {
        public override String Name
        {
            get { return "Derived Name"; }
        }
    }
