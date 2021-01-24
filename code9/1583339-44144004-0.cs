    public class Test
    {
        private readonly Mock<ILifetimeScope> _scopeMock;
        private readonly Mock<IDataContext> _contextMock;
        public Test()
        {
            _contextMock = new Mock<IDataContext>();
            _scopeMock = new Mock<ILifetimeScope>();
            _scopeMock.Setup( s => s.Resolve<IDataContext>() ).Returns( _contextMock.Object );
        }
    }
