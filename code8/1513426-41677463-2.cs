    public class EmailController : ApiController {
        [HttpPost]
        public async Task<IHttpActionResult> SendMailMessage([FromBody]Email message) {
            var myMail = new System.Net.Mail.MailMessage();
            myMail.Subject = message.Subject;
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;
            myMail.Body = message.Body;
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            myMail.IsBodyHtml = message.IsBodyHtml;
            myMail.From = new MailAddress("from@example.com");
            foreach (var to in message.To) {
                myMail.To.Add(to);
            }
            //...Code to send email
        }
    }
