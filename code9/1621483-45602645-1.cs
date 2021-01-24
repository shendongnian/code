    public class MailingInjection
    {
      ...
      public async Task SenMailAsync(string to, string subject, string body)
      {
        await mailing.SendMailAsync(to, subject,body).ConfigureAwait(false);   
      }
    }
