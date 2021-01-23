    Using System.Net.Mail
    protected void SendMail()
    {     
    Dictionary<string,string> recipients = new Dictionary<string,string>
    //--select FirstName, Email form MyClients
    //while reader.Read(){
      recipients.Add(Convert.ToString(reader[0]),Convert.ToString(reader[1]));//adds from user to dictionary
    //}
    //Mail notification
    
    
    foreach(KeyValuePair<string,string> kvp in recipients){
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(kvp.Value));
    
    
        message.Subject = "Hello,  "+kvp.Key;
        message.Body = "Email Message";
        message.From = new MailAddress("MyEmail@mail.com");
        // Email Address from where you send the mail
        var fromAddress = "MyEmail@mail.com";
        //Password of your mail address
        const string fromPassword = "password";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.mail.com";
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object        
        smtp.Send(message);
      }
    } //This bracket was outside the code box
