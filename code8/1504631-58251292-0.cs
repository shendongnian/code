    public static async Task<Tuple<string, string, string>> SendEmailUsingSendGrid(string filePath)
            {
                try
                {
                    var apiKey = EmailComponents.apiKey;
                    var client = new SendGridClient(apiKey);
                    var messageEmail = new SendGridMessage()
                    {
                        From = new EmailAddress(EmailComponents.fromEmail, EmailComponents.fromEmaliUserName),
                        Subject = EmailComponents.Subject,
                        PlainTextContent = EmailComponents.plainTextContent,
                        HtmlContent = EmailComponents.htmlContent
                    };
                    messageEmail.AddTo(new EmailAddress(EmailComponents.emailTo, EmailComponents.emailToUserName));
                    var bytes = File.ReadAllBytes(filePath);
                    var file = Convert.ToBase64String(bytes);
                    messageEmail.AddAttachment("Voucher Details Report.pdf", file);
    
    
                    var response = await client.SendEmailAsync(messageEmail);
    
                    return new Tuple<string, string, string>(response.StatusCode.ToString(), 
                        response.Headers.ToString(), 
                        response.Body.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
