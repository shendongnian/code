    string apiKey = "your API Key";
    dynamic sg = new SendGridAPIClient(apiKey);
    Email from = new Email("your@domain.com");
    string subject = "Hello World from the SendGrid CSharp Library!";
    Email to = new Email("destination@there.com");
    Content body = new Content("text/plain", "Hello, Email!");
    Mail mail = new Mail(from, subject, to, body);
    byte[] bytes = File.ReadAllBytes("C:/dev/datafiles/testData.txt");
    string fileContentsAsBase64 = Convert.ToBase64String(bytes);
    var attachment = new Attachment
    {
        Filename = "YourFile.txt",
        Type = "txt/plain",
        Content = fileContentsAsBase64
    };
    mail.AddAttachment(attachment);
    dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
