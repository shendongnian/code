    [TestClass]
    public class ExpressionMock {
        [TestMethod]
        public void TestFoo() {
            //Arrange
            var _mockedScope = new Mock<IScope>();
            _mockedScope
                .Setup(x => x.Execute<FooService, IList<Foo>>(It.IsAny<string>(), It.IsAny<Func<FooService, IList<Foo>>>()))
                .Returns(Result<IList<Foo>>.Success(new List<Foo>()));
            var subject = new Test(_mockedScope.Object);
            //Act
            var actual = subject.Foo();
            //Assert
            actual.Should().NotBeNull();
        }
    }
