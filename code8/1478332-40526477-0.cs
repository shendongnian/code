    public interface IDependency
    {
        int A { get; }
    }
    public class Dependency : IDependency
    {
        public int A { get; private set; }
        public Dependency()
        {
            // algorithms going on ...
            A = algorithm_output();
        }
        private static int algorithm_output()
        {
            return 42;
        }
    }
    public class ToTest
    {
        public int Xa;
        public void Foo(IDependency dep_input)
        {
            Xa = dep_input.A;
            // Xa will be used in an algorithm ...
        }
    }
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestWithMoq()
        {
            var dependecyMock = new Mock<IDependency>();
            dependecyMock.Setup(d => d.A).Returns(23);
            var toTest = new ToTest();
            toTest.Foo(dependecyMock.Object);
            Assert.AreEqual(23, toTest.Xa);
            dependecyMock.Verify(d => d.A, Times.Once);
        }
        [Test]
        public void TestWithStub()
        {
            var dependecyStub = new DependencyTest();
            var toTest = new ToTest();
            toTest.Foo(dependecyStub);
            Assert.AreEqual(23, toTest.Xa);
        }
        internal class DependencyTest : IDependency
        {
            public int A
            {
                get
                {
                    return 23;
                }
            }
        }
    }
