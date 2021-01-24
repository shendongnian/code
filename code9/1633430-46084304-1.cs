    [TestClass]
    public class DynamicFuncTest
    {
        [TestMethod]
        public void TestDynamicMapper()
        {
            var actualUser = new User { UserId = 1 };
            var actualAddress = new Address { PostCode = "12345", UserId = 1 };
            var testSetAddress = DynamicFuncHelper.CreateFunc(typeof(User), typeof(Address));
            var delegateResult = testSetAddress.DynamicInvoke(actualUser, actualAddress);
            Assert.AreEqual(actualUser, delegateResult, "Delegate result was not actualUser");
            Assert.AreEqual(actualAddress, actualUser.Address, "User address was not expected address");
        }
    }
