    public interface IMailing
    {
      string Host { get; set; }
      int Port { get; set; }
      Task SendMailAsync(string toAddress, string subject, string body);
      // No event necessary.
    }
    public class Mailing : IMailing
    {
      private SmtpClient client = new SmtpClient();
      MailMessage mm = null;
      public string Host{ get;  set; }
      public int Port { get; set; }
      public async Task SendMailAsync(string toAddress, string subject, string body)
      {            
        mm = new MailMessage(User, toAddress, subject, body);
        await client.SendMailAsync(mm).ConfigureAwait(false);
      }
    }
