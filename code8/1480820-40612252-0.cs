    [TestFixture]
    public class DependencyInjection
    {
        [TestMethod]
        public void TestAllocatedAgency()
        {
            var packet = new Mock<IPrimaryAllocationDP>();
            PrivateObject accessor = new PrivateObject(new MyClass());
            accessor.Invoke("SomeMethod", packet.Object); //Act
            packet.VerifySet(p => p.AllocatedAgency = 42);
        }
    }
    public interface IPrimaryAllocationDP
    {
        //object or any other type
        object AllocatedAgency { set; }
    }
    public class PrimaryAllocationDP : IPrimaryAllocationDP
    {
        public object AllocatedAgency { set; private get; }
    }
    public class MyClass
    {
        private readonly object AgencyAllocated = 42;
        private void SomeMethod(IPrimaryAllocationDP packet)
        {
            //........................
            //some code
            //........................
            packet.AllocatedAgency = AgencyAllocated;
        }
    }
