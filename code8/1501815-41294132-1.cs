    using System.Net;
    using System.Net.Mail;
    //...
    
    var fromAddress = new MailAddress("alextodorov01@abv.bg", "From Name");
    var toAddress = new MailAddress("kozichka01@abv.bg", "To Name");
    const string fromPassword = "fromPassword";
    const string subject = "an error ocurred";
    const string body = e.ToString();
    
    var smtp = new SmtpClient
    {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
    };
    using (var message = new MailMessage(fromAddress, toAddress)
    {
        Subject = subject,
        Body = body
    })
    {
        smtp.Send(message);
    }
    //...
