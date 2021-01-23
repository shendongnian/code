    interface IEmailSender
    {
       void SendEmail();
    }
    public class EmailSender : IEmailSender 
    {
       public void SendEmail()
       {
          throw new NotImplementedException();
       }
       public void DoOtherStuff()
       {
          throw new NotImplementedException();
       }
    }
