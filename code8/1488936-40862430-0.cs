    SmtpClient sc = new SmtpClient("mail address");
    MailMessage msg = null;
    
    try
    {
    msg = new MailMessage("xxxx@gmail.com",
        "yyyy@gmail.com", "Message from PSSP System",
        "This email sent by the PSSP system<br />" +
        "<b>this is bold text!</b>");
    
        msg.IsBodyHtml = true;
    
         sc.Send(msg);
    }
    
    catch (Exception ex)
    {
        throw ex;
    }
    
    finally
    {
        if (msg != null)
        {
            msg.Dispose();
        }
    }
