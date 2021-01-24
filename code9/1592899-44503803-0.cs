    [TestClass]
    public class AutoFixtureTests {
        [TestMethod]
        public void _FreezeBuildCreate() {
            //Arrange
            var expected = 10;
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Freeze<Mock<ISomeInterface>>().Setup(m => m.SomeProperty).Returns(expected);
            var builder = fixture.Build<SomeType>();
            var sut = builder.Create();
            //Act
            var actual = sut.GetA();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        public class SomeType {
            private ISomeInterface a;
            public SomeType(ISomeInterface a) {
                this.a = a;
            }
            public int GetA() {
                return a.SomeProperty;
            }
        }
        public interface ISomeInterface {
            int SomeProperty { get; set; }
        }
    }
