    public Task SendAsync(IdentityMessage message)
    {
        // Plug in your email service here to send an email.
        SmtpClient client = new SmtpClient();
    
        // Registering SendCompleted event and dispose SmtpClient after sending message
        client.SendCompleted += (s, e) => {
            client.Dispose();
        };
    
        return client.SendMailAsync("email from web config",
                                    message.Destination,
                                    message.Subject,
                                    message.Body);
    }
