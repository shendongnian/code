    public static IActionResult Run(HttpRequest req, TraceWriter log, out SendGridMessage message)
    {
        log.Info("C# HTTP trigger function processed a request.");
    
        message = new SendGridMessage();
        message.AddTo("you@gmail.com");
        message.AddContent("text/html", "Test body");
        message.SetFrom(new EmailAddress("test@test.com"));
        message.SetSubject("Subject");
    
        return new OkObjectResult("OK");
    }
