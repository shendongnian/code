    public interface IContainer<T> where T: UnitBase
    {
        void Add(T item);
        ....
    }
    public abstract class UnitBase
    {
        protected UnitBase(IContainer container)
        {
            Container = container;
        }
        IContainer Container { get; }
    }
