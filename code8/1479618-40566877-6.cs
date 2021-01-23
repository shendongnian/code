    [TestClass]
    public class TestOutputClass
    {
        [TestMethod]
        public void TestGoodNumber()
        {
            var testOutput = new TestOutputWithAValidNumber(1234);
            var h = new HomeWork(testOutput);
            h.Run();
            Assert.AreEqual(1234, testOutput.Value);
            Assert.AreEqual("Give me an integer:", testOutput.Outputs[0]);
            Assert.AreEqual("The double of 1234 is 2468", testOutput.Outputs[1]);
        }
        [TestMethod]
        public void TestWrongNumber()
        {
            var testOutput = new TestOutputWithNotValidNumber("foo");
            var h = new HomeWork(testOutput);
            h.Run();
            Assert.AreEqual("foo", testOutput.Value);
            Assert.AreEqual("Give me an integer:", testOutput.Outputs[0]);
            Assert.AreEqual("Wrong input! 'foo' is not an integer!", testOutput.Outputs[1]);
        }
    }
