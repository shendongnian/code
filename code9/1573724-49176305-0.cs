        [FunctionName("MyFunction")]
        public static async Task Run(
            [TimerTrigger("%TimerInterval%")]TimerInfo myTimer,
            [SendGrid] IAsyncCollector<Mail> messages,
            TraceWriter log)
        {
            log.Info($"C# Timer trigger function started execution at: {DateTime.Now}");
            // Do the work you already do...
            log.Info($"C# Timer trigger function finished execution at: {DateTime.Now}");
            var message = new Mail();
            message.From = new Email("from@email.com");
            var personalization = new Personalization();
            personalization.AddTo(new Email("to@email.com"));
            personalization.Subject = "Azure Function Executed Succesfully";
            message.AddPersonalization(personalization);
            var content = new Content
            {
                Type = "text/plain",
                Value = $"Function ran at {DateTime.Now}",
            };
            message.AddContent(content);
            await messages.AddAsync(message);
        }
