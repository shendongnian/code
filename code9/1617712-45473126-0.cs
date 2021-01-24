    var reply = context.MakeMessage();
    var card = new AdaptiveCard();
    
    var choices = new List<Choice>();
    choices.Add(new Choice()
    {
        Title = "Category 1",
        Value = "c1"
    });
    choices.Add(new Choice()
    {
        Title = "Category 2",
        Value = "c2"                       
    });
    var choiceSet = new ChoiceSet()
    {
        IsMultiSelect = false,
        Choices = choices,
        Style = ChoiceInputStyle.Compact,
        Id = "Category"
    };
    card.Body.Add(choiceSet);
    card.Actions.Add(new SubmitAction() { Title = "Select Category", Data = Newtonsoft.Json.Linq.JObject.FromObject(new { button = "select" }) });
    
    reply.Attachments.Add(new Attachment()
    {
        Content = card,
        ContentType = AdaptiveCard.ContentType, 
        Name = $"Card"
    });
    
    await context.PostAsync(reply);
