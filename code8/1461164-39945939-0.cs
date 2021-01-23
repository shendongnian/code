        public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public IConfiguration Configuration { get; set; }
        public string EmailPass; //Added public variable
        public AuthMessageSender(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            EmailPass = Configuration["AdminPassword:Email"];//Assigned value to variable
        }
        public async Task SendEmailAsync(string email, string subject, string message, string fullName)
        {
            try
            {
                var _email = "info@*******.co.uk";
                string _epass = EmailPass;// passed variable in
                var _dispName = "Mark Perry";
                var myMessage = new MimeMessage();
                var builder = new BodyBuilder();
                myMessage.To.Add(new MailboxAddress(fullName ?? "User", email));
                myMessage.From.Add(new MailboxAddress(_dispName, _email));
                myMessage.Subject = subject;
                builder.HtmlBody = message;
                myMessage.Body = builder.ToMessageBody();
                using (SmtpClient smtp = new SmtpClient())
                {
                    bool UseSSL = true;
                    string Host = "just22.justhost.com";
                    int Port = 465;
                    await smtp.ConnectAsync(Host, Port, UseSSL).ConfigureAwait(true);
                    smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                    smtp.Authenticate(_email, _epass); // Note: only needed if the SMTP server requires authentication
                    await smtp.SendAsync(myMessage).ConfigureAwait(false);
                    await smtp.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
