    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using SendGrid.Helpers.Mail;
    
    public static class ExtractArchiveBlob
    {
        [FunctionName("MyFunction")]
        public static async Task RunAsync(string input, 
                                          [SendGrid(ApiKey = "SendGridApiKey")] 
                                          IAsyncCollector<SendGridMessage> messageCollector)
        {
                var message = new SendGridMessage();
    
                message.AddContent("text/plain", "Example content");
                message.SetSubject("Example subject");
                message.SetFrom("from@email.com");
                message.AddTo("to@email.com");
    
                await messageCollector.AddAsync(message);
       }
    }
