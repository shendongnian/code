    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
    
        if (message.Attachments != null && message.Attachments.Any())
        {
            var attachment = message.Attachments.First();
            using (HttpClient httpClient = new HttpClient())
            {
                // Skype attachment URLs are secured by a JwtToken, so we need to pass the token from our bot.
                if (message.ChannelId.Equals("skype", StringComparison.InvariantCultureIgnoreCase) && new Uri(attachment.ContentUrl).Host.EndsWith("skype.com"))
                {
                    var token = await new MicrosoftAppCredentials().GetTokenAsync();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
    
                var responseMessage = await httpClient.GetAsync(attachment.ContentUrl);
    
                var contentLenghtBytes = responseMessage.Content.Headers.ContentLength;
    
                await context.PostAsync($"Attachment of {attachment.ContentType} type and size of {contentLenghtBytes} bytes received.");
            }
        }
        else
        {
            await context.PostAsync("Hi there! I'm a bot created to show you how I can receive message attachments, but no attachment was sent to me. Please, try again sending a new message including an attachment.");
        }
    
        context.Wait(this.MessageReceivedAsync);
    }
