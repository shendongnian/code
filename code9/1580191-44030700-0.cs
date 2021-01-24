    public static async Task NewPassword(string mail, string name, string password)
    {
        MailDefinition oMailDefinition = new MailDefinition();
        oMailDefinition.BodyFileName = "~/img/emailskabelon/NewPassword.html";
        oMailDefinition.From = OrdklarMail;
        Dictionary<string, string> oReplacements = new Dictionary<string, string>();
        oReplacements.Add("<<navn>>", name);
        oReplacements.Add("<<password>>", password);
        MailMessage oMailMessage = oMailDefinition.CreateMailMessage(mail, oReplacements, new LiteralControl());
        oMailMessage.Subject = Password;
        oMailMessage.IsBodyHtml = true;
        using(SmtpClient smtp = new SmtpClient(AzureApi))
        {
            NetworkCredential netcred = new NetworkCredential(AzureName, AzurePassword);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = netcred;
            smtp.Port = Port25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(oMailMessage);
        }
    }
