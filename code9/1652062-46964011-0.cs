    string FormatMessage(string soapMessage, IDictionary<string, string> parameters)  {
        var message = soapMessage;
        foreach (var kvp in parameters) {
            message = message.Replace("{" + kvp.Key + "}", kvp.Value);
        }
        return message;
    }
