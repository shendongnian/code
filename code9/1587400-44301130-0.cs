    [TestClass]
    public class PersonRegistration
    {
     
        [TestMethod]
        public void TestMethod()
        {
            RegisterBindingModel model = new RegisterBindingModel();
    
            var mockService = new Mock<ILoggingService>();//Mock
            var mockManager = new Mock<IUserManager>();//Mock
    
            AccountController ac = new AccountController(mockManager.Object, mockService.Object);
            model.UserName = "test123@gmail.com";
            var result = ac.Register(model);
            Assert.AreEqual("User Registered Successfully", result);
        }
    }
