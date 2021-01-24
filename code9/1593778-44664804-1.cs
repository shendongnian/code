        using (var client = new SmtpClient())
        {
            client.LocalDomain = "smtp.office365.com";
            await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls).ConfigureAwait(false);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate("EmailAddress", "Password");
            await client.SendAsync(emailMessage).ConfigureAwait(false);
            await client.DisconnectAsync(true).ConfigureAwait(false);
        }
