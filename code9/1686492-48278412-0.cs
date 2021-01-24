    #r "SendGrid"
    using SendGrid.Helpers.Mail;
    using System.Net;
    
    public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log, out Mail message)
    {
        log.Info("C# HTTP trigger function processed a request.");
        message = new Mail
        {        
            Subject = "Azure news"          
        };
    
        var personalization = new Personalization();
        personalization.AddTo(new Email("example@test.com"));   
    
        Content content = new Content
        {
            Type = "text/plain",
            Value = "msp"
        };
        message.AddContent(content);
        message.AddPersonalization(personalization);
        return req.CreateResponse(HttpStatusCode.OK,"hello");
    }
