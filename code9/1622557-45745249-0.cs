    public abstract class A
    {
        public IFunctionality Functionality { get; set; }
        public A()
        {
            Type t = GetFunctionalityType;
            Functionality = (IFunctionality)Activator.CreateInstance(t);
        }
        protected virtual GetFunctionalityType { get { return typeof(FDefault); } }
    }
    public class B : A { }
    public class BSpecific : B
    {
        public override GetFunctionalityType { get { return typeof(FSpecific); }}
    }
