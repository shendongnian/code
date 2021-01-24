     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Net;
     using System.Web;
     using System.Web.UI;
     using System.Web.UI.WebControls;
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
        var fromAddress = "";
        var toAddress = "";
        //Password of your gmail address
        const string fromPassword = "";
        string subject = "";
        string body = "";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com"";
            smtp.Port = 587;
            smtp.EnableSsl = false;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
       }
      }  
     }
