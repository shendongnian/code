    public class SimpleEmailTest
    {
       private int _sentEmails;
       
       public SimpleEmailTest()
       {
          this._sentEmails = 0;
       }
    
       [TestMethod]
       public void TestIfEmailsGetSent()
       {
          SendEmail();
          
          Assert.IsTrue(_sentEmails == 1);
       }
    
       public void SendEmail
       {
           // do email sending
           _sentEmails++;
       }
    }
