    {
      "Email": {
        "ToEmails": [
          "test1@test.com",
          "test2@test.com",
          "test3@test.com"
        ]
    }
    
    List<string> emailTo = _config.GetSection("Email:ToEmails").Get<List<string>>()
    
    foreach (string email in emailTo)
    {
        sendGridMessage.AddTo(new EmailAddress(email));
    }
