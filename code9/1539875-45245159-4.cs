    <pre>public class GmailEmailService:SmtpClient
    {
        // Gmail user-name
        public string UserName { get; set; }
        public GmailEmailService() :
            base(ConfigurationManager.AppSettings["GmailHost"], Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]))
        {
            //Get values from web.config file:
            this.UserName = ConfigurationManager.AppSettings["GmailUserName"];
            this.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["GmailSsl"]);
            this.UseDefaultCredentials = false;
            this.Credentials = new System.Net.NetworkCredential(this.UserName, ConfigurationManager.AppSettings["GmailPassword"]);
        }
    }</pre>
