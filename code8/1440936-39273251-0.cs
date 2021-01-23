    To Send email using Gmail server we need to set following thing.Use these namespaces in C#.
      
    
         1. using System.IO;
         2. using System.Net;
         3. using System.Net.Mail;
    
    MailMessage Class Properties
    
    Following are the required properties of the MailMessage class.
    
     - From – Sender’s email address 
     - To – Recipient(s) Email Address 
     - CC –Carbon Copies (if any) 
     - BCC – Blind Carbon Copies (if any) 
     - subject –Subject of the Email  
     - Body – Body of the Email 
     - IsBodyHtml – Specify whether body contains text or HTML tag.
     - Attachments – Attachments(if any)
     - ReplyTo – ReplyTo Email address.
    
     SMTP Class Properties
      
      Following are the properties of the SMTP class.
      - Host – SMTP Server URL (Gmail: smtp.gmail.com)
      - EnableSsl – Specify whether your host accepts SSL Connections (Gmail: True)
      - UseDefaultCredentials – Set to True in order to allow authentication based on the Credentials of the Account used to send emails
      - Credentials – Input valid username and password
      - Port – Assign port number for (Gmail: 587)
     
    Finally here is your Code.  
    
           using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + your username.Trim() + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + new Uri("http://www.google.com", true).AbsoluteUri + "<a>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(username, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
