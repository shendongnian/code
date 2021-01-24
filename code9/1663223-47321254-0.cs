        public async Task<bool> SendEmail(string from, string to, string subject, string html){
        // might want to provide credentials
        using(var ses = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1)) 
    
           {
        var sendResult = await ses.SendEmailAsync(new SendEmailRequest
                {
                      Source = from,
                      Destination = new Destination(to) { CcAddresses = "if you need them", BccAddresses = "or these" },
                      Message = new Message
                         {
                           Subject = new Content(subject),
                           Body = new Body
                           {
                              Html = new Content(html)
                           }
                         }
                     });
             return sendResult.HttpStatusCode == HttpStatusCode.OK;
           }
    }
