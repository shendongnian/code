    [TestClass]
    public class TestClasse {
        [TestMethod]
        public void TestShow() {
            //Arrange
            var foo = Mock.Interface<IFoo>();
            Expect.Once.MethodCall(()=> foo.Show(Any<MyObj>.Value.Matching(obj => obj.Attr == 1)));
            //Act
            var objectUnderTest = new ObjUnderTest(foo);
            //Assert
            AssertExpectations.IsMetFor(foo);
        }
    }
