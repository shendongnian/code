    private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient,
    string subject, string messageBody)
    {
        var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
        emailMessage.Body = messageBody;
        var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
        if (email != null)
        {
            var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
            emailMessage.To.Add(emailRecipient);
            emailMessage.Subject = subject;
        }
        await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
    }
