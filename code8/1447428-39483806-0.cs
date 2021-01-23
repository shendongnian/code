        public class Customer
        {
          private MyEmail _myEmail;
          public void Customer(MyEmail myEmail)
          {
            _myEmail = myEmail;
          }
        
          public bool Addcustomer()
          {     
             _myEmail.SendEmail();
             return true;
          }
        }
    
    [TestMethod()]
    public void AddCustomerTest()
    {
      Mock<Myemail> objemail = new Mock<Myemail>();
    
      objemail.Setup(x=>x.SendEmail()).Returns(true);
      customer obj = new Customer(objemail.Object);
    
      //Assert something
    }
