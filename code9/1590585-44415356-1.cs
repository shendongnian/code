    interface IBase<T>
    {
        void CloneMeToProvidedEntity(T destination);
    }
    public abstract class Base<T> : IBase<T>
    {
        public virtual void CloneMeToProvidedEntity(T destination) { }
    }
    public class Derived : Base<Derived>
    {
        public override void CloneMeToProvidedEntity(Derived destination)
        {
        }
    }
