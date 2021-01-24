    public abstract class Base<T> : IBase where T : IBase
    {
        public virtual void CloneMeToProvidedEntity(T destination) { }
    }
    public class Derived : Base<Derived>
    {
        public override void CloneMeToProvidedEntity(Derived destination)
        {
            // blah blah ....
        }
    }
