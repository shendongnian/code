    [NotChildAction]
    [HttpPost]
    public ActionResult ContactForm(ContactFormModel model)
    {
        var fromAddress = new MailAddress("xxx@gmail.com", model.Name);
        var toAddress = new MailAddress("xxx@gmail.com", "To Name");
        string fromPassword = "xxx";
        string subject = model.Subject;
        string body = model.Message;
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            Timeout = 20000
        };
        if (!ModelState.IsValid)
        {        
            return PartialView("_Error");
        }
        var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = model.Subject,
            Body = "test"
        };
        smtp.Send(message);
        return PartialView("_Success");
    }
