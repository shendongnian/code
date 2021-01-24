    private async Task ComposeEmail()
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = "Hello, this is sample email body.";
            var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient("some@email.com");
            emailMessage.To.Add(emailRecipient);
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
