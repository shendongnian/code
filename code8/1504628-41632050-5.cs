    // Documentation: https://sendgrid.com/docs/API_Reference/Web_API_v3/Mail/index.html
    public class SendGridEmailSender : IEmailSender
    {
        private readonly HttpClient httpClient;
        public SendGridEmailSender(string apiKey)
        {
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            this.httpClient.BaseAddress = new Uri("https://api.sendgrid.com/v3/");
        }
        // TODO: Delete custom code and use their library once the SendGrid library starts to support .NET Core
        // Implemented using custom SendGrid API usage implementation due to lack of .NET Core support for their library
        public async Task Send(
            string fromAddress,
            string fromName,
            string to,
            string subject,
            string message,
            IEnumerable<string> bcc = null)
        {
            var bccEmails = bcc?.Select(c => new SendGridEmail { Email = c, Name = fromName });
            var msg = new SendGridMessage(
                new SendGridEmail(to),
                subject,
                new SendGridEmail(fromAddress, fromName),
                message,
                bccEmails);
            try
            {
                var json = JsonConvert.SerializeObject(msg);
                var response = await this.httpClient.PostAsync(
                    "mail/send",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    // See if we can read the response for more information, then log the error
                    var errorJson = await response.Content.ReadAsStringAsync();
                    throw new Exception(
                        $"SendGrid indicated failure! Code: {response.StatusCode}, reason: {errorJson}");
                }
            }
            catch (Exception)
            {
                // TODO: await this.logger.LogExceptionAsync(ex);
            }
        }
    }
