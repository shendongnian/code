    var props = new PropertySet(BasePropertySet.FirstClassProperties, 
        EmailMessageSchema.UniqueBody,
        EmailMessageSchema.Subject,
        EmailMessageSchema.To,
        EmailMessageSchema.From
    
    props.RequestedBodyType = BodyType.HTML;
    
    var message = EmailMessage.Bind(subscription.Service, item.ItemId, props);
    
    // Should be unique
    var uniqueBody = message.UniqueBody.Text;
