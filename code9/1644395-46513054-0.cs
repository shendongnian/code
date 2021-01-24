    public interface IInterface
    {
        void SomeMethod();
    }
    public abstract class BaseClass : IInterface
    {
        public abstract void SomeMethod();
        // Or virtual with common implementation
    }
    public class DerivedA : BaseClass
    {
        public override void SomeMethod()
        {
            // some implementation
        }
    }
    public class DerivedB : BaseClass
    {
        public override void SomeMethod()
        {
            // some other implementation
        }
    }
