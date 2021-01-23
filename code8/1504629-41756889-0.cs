     // using SendGrid's C# Library - https://github.com/sendgrid/sendgrid-csharp
    using System.Net.Http;
    using System.Net.Mail;
    
    var myMessage = new SendGrid.SendGridMessage();
    myMessage.AddTo("test@sendgrid.com");
    myMessage.AddTo("test@sendgrid.com");
    myMessage.AddTo("test@sendgrid.com");
    myMessage.From = new MailAddress("you@youremail.com", "First Last");
    myMessage.Subject = "Sending with SendGrid is Fun";
    myMessage.Text = "and easy to do anywhere, even with C#";
    
    var transportWeb = new SendGrid.Web("SENDGRID_APIKEY");
    transportWeb.DeliverAsync(myMessage);
