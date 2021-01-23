    var messageText = string.Empty;
    
    /// In case there are more needed fields
    foreach (var element in responseMessage.ExtraParameters.Elements ())
    {
        var name = element.Name.LocalName;
        var value = element.Value;
        if (!string.IsNullOrWhiteSpace (name) && !string.IsNullOrWhiteSpace (value))
        {
            switch (name)
            {
                case "message_text":
                    messageText = value
    
                default:
                    break;
            }
        }
    }
