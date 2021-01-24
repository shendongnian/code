    [TestClass]
    public class PersonRegistration
    {
     
        [TestMethod]
        public void TestMethod()
        {
            RegisterBindingModel model = new RegisterBindingModel();
    
            var mockService = new Mock<ILoggingService>();//Mock
       //Do something as per your requirement 
       //var reg= new List<RegisterBindingModel >(); // provide some sample list 
        //mockService .Setup(r => r.GetAll=()).Return(reg);
            var mockManager = new Mock<IUserManager>();//Mock
    
        //Do something as per your requirement 
        //var user= new List<User>(); // provide some sample list 
        //mockManager .Setup(r => r.GetAll=()).Return(user);
            AccountController ac = new AccountController(mockManager.Object, mockService.Object);
            model.UserName = "test123@gmail.com";
            var result = ac.Register(model);
            Assert.AreEqual("User Registered Successfully", result);
        }
    }
