    [TestClass] //<--- Test classes must have this attribute to discover test methods
    public class AccountTests {
        [TestInitialize]
        public void Arrange() {
            //...code removed for brevity
        }
        [TestMethod]
        public void GetAccounts() {
            var testAccount = this.MockDatabase.GetAccounts();
            Assert.IsNotNull(testAccount);
            Assert.AreEqual(4, testAccount.Count);
        }
    
        //...code removed for brevity
    }
