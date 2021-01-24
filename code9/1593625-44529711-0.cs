    [TestFixture]
    public class Class1Tests
    {
        [Test]
        public void DoSomething1_DoSomething2IsCalled()
        {
            //Setup 
            var mock = new Mock<Interface2>();
            var sut = new Class1(mock.Object);
            //execute
            sut.DoSomething1(It.IsAny<int>());
            //test
            mock.Verify(m => m.DoSomething2(It.IsAny<int>()), Times.Once());
        }
    }
