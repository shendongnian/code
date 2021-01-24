    [TestClass]
    public class MyClassTests
    {
       MyClass _sut;
       Mock<IDependency> _mockDependency;
       Dependency _realDependency;
       [TestInit]
       public void Init()
       {
          var shouldUseMock = ConfigurationManager.AppSettings["key"];
          if(shouldUseMock)
          {
             _mockDependency = new Mock<IDependency>();
            _sut = new MyClass(_mockDependency.Object) 
          }
          else
          {
            _realDependency = new Dependency();
            _sut = new MyClass(_realDependency);
          }
       }
    }
