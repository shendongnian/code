    string sampleContent = Base64Encode("Testing");  // base64 encoded string
    var client = new SendGridClient("apiKey");
    var msg = new SendGridMessage()
        {
            From = new EmailAddress(sender),
            Subject = "Adherence Report",
            PlainTextContent = "Sample Content ",
            HtmlContent = "<strong>Hello, Email!</strong>"
        };
            msg.AddTo(new EmailAddress(recipient, null));
            msg.AddAttachment("myfile.csv", sampleContent, "text/csv", "attachment", "banner");
        var response = await client.SendEmailAsync(msg);
