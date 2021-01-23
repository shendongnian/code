    public interface IB
    { }
    public class B : IB
    { }
    public class Bext : IB
    { }
    public class A
    {
        public virtual IB Details { get; set; }
        public A(IB details)
        {
            Details = details;
        }
    }
    public class TestClass
    {
        public void TestMethod()
        {
            IB details = new B();
            IB extDetails = new Bext();
            A instance1 = new A(details);
            A instance2 = new A(extDetails);
        }
    }
