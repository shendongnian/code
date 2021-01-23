    [HttpPost]
    public ActionResult SendReminder(string[] userId, FormCollection formCollection)
    { 
        string fName=String.Empty;
        string[] arrFName = Convert.ToString(formCollection["hdnFName"]).Split(',');           
        using (SmtpClient objSmtpClient = new SmtpClient())
        {
            for (int emailCount = 0; emailCount < userId.Length; emailCount++)
            {
            //first name
             fName= arrFName[emailCount];
                if (!string.IsNullOrEmpty(userId[emailCount]))
                {
                    using (MailMessage mail = new MailMessage("sender@gmail.com", userId[emailCount].Trim()))
                    {
                        mail.Subject = "Test Email";
                        mail.Body = "Test Body";
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient())
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.Credentials = new System.Net.NetworkCredential("sender@gmail.com", "password");
                            smtp.EnableSsl = true;
                            mail.IsBodyHtml = true;
                            smtp.Send(mail);
                        }
                    }
                }
            }
        }
        return View();
    }
