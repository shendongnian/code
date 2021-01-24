    public async Task<MailChimpResponse> SubscribeEmailAsync()
    {
        IMailChimpManager mailChimpManager = new MailChimpManager(ConfigurationManager.AppSettings["testing"]);
        MailChimpResponse mcResponse = new MailChimpResponse();
        var listId = "xxxxxxxxx";
    
        try
        {
            var mailChimpListCollection = await mailChimpManager.Members.GetAllAsync(listId).ConfigureAwait(false);
    
            mcResponse.IsSuccessful = true;
            mcResponse.ReponseMessage = "Success!";
        }
        catch (AggregateException ae)
        {
            mcResponse.IsSuccessful = false;
            mcResponse.ReponseMessage = ae.Message.ToString();
        }
    
        return mcResponse;
    }
