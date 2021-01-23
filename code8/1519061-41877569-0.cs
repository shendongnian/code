    public interface IEmailManager {
        Task SendEmailAsync();
    }
    public class EmailManager : IEmailManager {
        private string mailTemplate;
        private Merchant merchant;
        private string subject;
        public EmailManager(string mailTemplate, Merchant merchant, string subject) {
            this.mailTemplate = mailTemplate;
            this.merchant = merchant;
            this.subject = subject;
        }
        private async Task<string> GetEmailTemplateAsync(string mailTemplate) {
            var mailBody = String.Empty;
            //Get Mail Text Path
            var path = HostingEnvironment.MapPath("/Content/MailText/" + mailTemplate);
            //mailBody = System.IO.File.ReadAllText(HostingEnvironment.MapPath("/Content/MailText/" + mailTemplate));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var sr = new StreamReader(fs)) {
                mailBody = await sr.ReadToEndAsync();
            }
            return mailBody;
        }
        private string BuildVerifyEmailBodyForMerchant(string mailBody, Merchant merchant) {
            //Replace Custom Variables for Email Body
            var url = System.Web.HttpContext.Current.Request.Url;
            var urlLink = url.OriginalString.Replace(url.PathAndQuery, "");
            merchant.ProviderUserKey = Guid.NewGuid().ToString();
            urlLink = String.Concat(urlLink, "/");
            var verifyUrl = urlLink + "business/verify/" + merchant.ProviderUserKey.ToString();
            //replace variables 
            mailBody = mailBody.Replace("~userLastName~", merchant.Name);
            mailBody = mailBody.Replace("~name~", String.Format("{0} {1}", merchant.FirstName, merchant.LastName));
            mailBody = mailBody.Replace("~companyName~", merchant.Name);
            mailBody = mailBody.Replace("~dateOfRegistration~", merchant.DateOfRegistration.Value.ToShortDateString());
            mailBody = mailBody.Replace("~verifyUrl~", verifyUrl);
            mailBody = mailBody.Replace("~email~", merchant.Email);
            return mailBody;
        }
        private MailMessage BuildEmailMessage(string body, string subject, Merchant merchant) {
            var msg = new MailMessage();
            msg.From = new MailAddress("no-reply@mydomain.com");
            msg.To.Add(merchant.Email.ToString());
            msg.Subject = subject;
            msg.Body = body;
            return msg;
        }
        public async Task SendEmailAsync() {
            var emailTemplate = await GetEmailTemplateAsync(mailTemplate);
            var emailBody = BuildVerifyEmailBodyForMerchant(emailTemplate, merchant);
            var emailToSend = BuildEmailMessage(emailBody, subject, merchant);
            using (var client = new SmtpClient()) {
                await client.SendMailAsync(emailToSend);
            }
        }
    }
