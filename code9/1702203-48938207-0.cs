    protected override Task<string> GetLuisQueryTextAsync(IDialogContext context, IMessageActivity message)
    {
        if (message.Value != null) 
        {
             dynamic value = message.Value;
             // assuming your DataJson has a type property like :
             // DataJson = "{ \"Type\": \"Curse\" }" 
             string submitType = value.Type.ToString();
             return Task.FromResult(submitType);
        }
        else 
        {
           // no Adaptive Card value, let's call the base
           return base.GetLuisQueryTextAsync(context, message);
        }
    }
