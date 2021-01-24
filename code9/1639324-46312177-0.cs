    using System.Net.Mail;
    //...
    public ActionResult SendEmail(string msg, int formNum)
    {
    	var sent = false;
    	try
    	{
    		var emailClient = new SmtpClient();
    		var mailMessage = new MailMessage(fromEmail, toEmail);
    		mailMessage.Subject = emailsubject +" " + formNum;
    		mailMessage.Body = msg;
            mailMessage.IsBodyHtml = true;
    		emailClient.Send(mailMessage);
            sent = true;
    		// from and to values are defined. 
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("Exception occured while sending Email " + ex.Message);
    	}
    	return Json(sent, JsonRequestBehavior.AllowGet);
    }  
