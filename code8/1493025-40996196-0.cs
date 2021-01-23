    private void SendEmail(string email, string content)
    {
        try
        {
            SendEmailAsync(email, content).GetAwaiter().GetResult();
        }
        catch(Exception ex)
        {
            // ex is the original exception
            // Handle ex or rethrow or don't even catch
        }
    }
