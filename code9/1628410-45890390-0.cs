    public class ConcreteClass : BaseClass<ListClass>
    {
        public override List<ListClass> History { get; set; }
    }
    public abstract class BaseClass<T> where T : BaseListClass
    {
        public abstract List<T> History { get; set; }
    }
    public abstract class BaseListClass
    {
    }
    public class ListClass : BaseListClass
    {
    }
