    [TestFixture()]
    class Class1UnitTest {
        private Mock<ITest1> iTest1;
        private ITest[] iTests;
        private Class1 class1;
    
        [SetUp]
        public void setUp () {
          this.iTest1 = new Mock<ITest1>();
    
          var mock1 = new Mock<ITest>();
          var mock2 = new Mock<ITest>();
          var mock3 = new Mock<ITest>();
    
          this.iTests = new ITest[] {
              mock1.Object,
              mock2.Object,
              mock3.Object,
              //...
          }
          class1 = new Class1 (this.iTest1.Objeсt, this.iTests);
        }
    }
