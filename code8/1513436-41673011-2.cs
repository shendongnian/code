    var email = new EmailEntity(phoneCall);
    using (var client = new HttpClient())
    {
        var uri = new Uri("http://url/email/send");
        var content = new StringContent(
            JsonConvert.SerializeObject(new
            {
                Address = email.Recipient,
                Subject = email.Title,
                Body = email.body,
            }),
            UnicodeEncoding.UTF8,
            "application/json");
        var msg = await client.PostAsync(uri, content);
    }
