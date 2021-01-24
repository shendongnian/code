    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mail;
    using Microsoft.Office.Interop.Word;
    
    namespace Project
    {
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Open("C:\\Users\\name\\Desktop\\word.docx");
    
            int count = document.Paragraphs.Count;
    		
    		string totaltext = "";
    		List<string> rows = new List<string>();
    		
            for (int i = 1; i <= count; i++)
            {
                 string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
    			if (temp != string.Empty)
    				rows.Add(temp);
            }
    		//WE HAVE ROWS IN WORD DOCUMENT. NOW WE CAN SEND.
    		string mailTo= rows[0];
    		string name= rows[1];
    		string subject= rows[2];
    		string messageBody = rows[3];
    		string attachmentPath=rows[4];
    		 try 
                {
                    MailMessage oMsg = new MailMessage();
                    // TODO: Replace with sender e-mail address.
                    oMsg.From = "sender@somewhere.com";
                    // TODO: Replace with recipient e-mail address.
                    oMsg.To = name+"<"+mailTo+">";
                    oMsg.Subject = subject;
                    
                    // SEND IN HTML FORMAT (comment this line to send plain text).
                    oMsg.BodyFormat = MailFormat.Html;
                    
                    // HTML Body (remove HTML tags for plain text).
                    oMsg.Body = messageBody;
                    
                    // ADD AN ATTACHMENT.
                    // TODO: Replace with path to attachment.
                    String sFile = attachmentPath;  
                    MailAttachment oAttch = new MailAttachment(sFile, MailEncoding.Base64);
      
                    oMsg.Attachments.Add(oAttch);
    
                    // TODO: Replace with the name of your remote SMTP server.
                    SmtpMail.SmtpServer = "MySMTPServer";
                    SmtpMail.Send(oMsg);
    
                    oMsg = null;
                    oAttch = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
    		
        }
    }
    }
