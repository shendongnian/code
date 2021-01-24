    private async Task SendEmails()
    {
        foreach (var chunk in _recipients.Chunk(100))
        {
            var sendTasks = new List<Task>();
            foreach (var recipient in chunk)
            {
                sendTasks.Add(SendEmail(recipient)); // your SendEmail method here
            }
            await Task.WhenAll(sendTasks);
            await Task.Delay(1000);
        }
    }
    private async Task SendEmail(string recipient)
    {
        // your send email logic here
    }
