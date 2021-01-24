    interface IBase
    {
    }
    public abstract class Base<T> : IBase where T : Base<T>
    {
        public virtual void CloneMeToProvidedEntity(T destination) { }
    }
    public class Derived : Base<Derived>
    {
        public override void CloneMeToProvidedEntity(Derived destination)
        {
        }
    }
