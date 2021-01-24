    private string FormatMessage(string soapMessage, IDictionary<string, string> parameters) {
        var message = soapMessage;
        foreach (var kvp in parameters) {
            var placeholder = "{" + kvp.Key + "}";
            if (message.IndexOf(placeholder) > -1) {
                message = message.Replace(placeholder, kvp.Value);
            }
        }
        return message;
    }
