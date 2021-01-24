    public class MyClassA : SomeAbstractClass, ISomeInterface1, ISomeInterface2 {
        //...
    }
    public class MyClassB : SomeAbstractClass, ISomeInterface1, ISomeInterface2 {
        //...
    }
    public class TestClass {
        [Test]
        public void TestMethod() {
            var stub1 = new MockRepository().StrictMock<MyClassA>("some data 1");
            var stub2 = new MockRepository().StrictMock<MyClassB>("some data 2");
    
            Assert.AreEqual(stub1.CheckId, stub2.CheckId);
        }
    }
