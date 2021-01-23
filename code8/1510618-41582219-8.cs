    public class EmailService {
    
        public UserData SendEmail(UserData user, string confirmationEmailUrl) {
            try
            {
                #region Email content
    
                MailMessage m = new MailMessage(
                new MailAddress("sender@email.com", "Represent Location"),
                new MailAddress(Reciever_Email));
                m.Subject = "Mail Topic";
    
                m.IsBodyHtml = true;
    
                m.Body = string.Format("<img src=\"@@IMAGE@@\" alt=\"\"><BR/><BR/>Hi " + user.FirstName + "," + "<BR/><BR/>Your account has been successfully created. Please click on the link below to access your account.<BR/><BR/>" + "Username - " + user.UserName + "<BR/>" + "Password - " + user.Password + "<BR/><BR/>" + "<a href=\"{1}\" title=\"User Email Confirm\">Please click here to Activate your account</a>", user.UserName, confirmationEmailUrl + string.Format("<BR/><BR/>Regards,<BR/>The Human Resource Department <BR/>");
    
                // create the INLINE attachment      
                string attachmentPath = System.Web.HttpContext.Current.Server.MapPath("~/Images/logo.jpg");
    
                // generate the contentID string using the datetime
                string contentID = Path.GetFileName(attachmentPath).Replace(".", "") + "@zofm";
    
                Attachment inline = new Attachment(attachmentPath);
                inline.ContentDisposition.Inline = true;
                inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                inline.ContentId = contentID;
                inline.ContentType.MediaType = "image/png";
                inline.ContentType.Name = Path.GetFileName(attachmentPath);
                m.Attachments.Add(inline);
    
                // replace the tag with the correct content ID
                m.Body = m.Body.Replace("@@IMAGE@@", "cid:" + contentID);
    
                SmtpClient smtp = new SmtpClient("Email_Server_IP");
                smtp.Port = ServerPort;
                smtp.Credentials = new NetworkCredential("sender@email.com", "sender_password");
                smtp.EnableSsl = false;
                smtp.Send(m);
    
                #endregion
    
                return user;
    
            }
    
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
