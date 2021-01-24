    public class RegisterBindingModel
    {   
        [Display(Name = "User name")]
        [Required]
        public string UserName { get; set; }
    }
    public class PersonRegistration
    {
        RegisterBindingModel model= new RegisterBindingModel ();
        [TestMethod]
    
        public void TestMethod1()
        {
            AccountController ac = new AccountController(userManager, loggingService);
            model.UserName = "test123@gmail.com";
            var result = ac.Register(model);
            Assert.AreEqual("User Registered Successfully", result);
        }
