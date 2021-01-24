        public interface I
        {
          T Execute<T>(Func<T> func);
        }
        [TestMethod]
        public void TestMethod1()
        {
          var mock = new Mock<I>();
          mock.Setup(x => x.Execute<string>(It.IsAny<Func<string>>())).Returns((Func<string> x) => x());
    
          Func<string> myFunc = () => "test";
    
          Assert.AreEqual("test", mock.Object.Execute(myFunc));
        }
