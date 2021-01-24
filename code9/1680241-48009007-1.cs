    public class TestClass {
        [Test]
        public void TestMethod() {
            var stub1 = new MockRepository().StrictMock<MyClassA>("some data 1", "checkId 1");
            var stub2 = new MockRepository().StrictMock<MyClassA>("some data 2", "checkId 2");
    
            Assert.AreEqual(stub1.CheckId, stub2.CheckId); //Should fail.
        }
    }
