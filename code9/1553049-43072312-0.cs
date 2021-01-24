    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    namespace SendEmail
    {
    public partial class SendEmail : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            SendMail();
        }
        protected void SendMail()
        {
            MailMessage mail = new MailMessage();
     
            mail.From = new MailAddress("");
            mail.To.Add("");
            mail.Subject = "INCOMPLETE APPLICATION CASE ID [CASE ID]";
            mail.Body = "Your Incomplete Grade Application has been Result[]";
            System.Net.Mail.Attachment attachment;
            attachment = new  System.Net.Mail.Attachment(Server.MapPath("files/test.pdf"));
            mail.Attachments.Add(attachment);
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "10.12.46.3";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("", "");
            }
            smtp.Send(mail);
        }
     }
     }
 
