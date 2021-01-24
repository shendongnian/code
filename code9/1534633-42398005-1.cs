    var rawMessage = "";
    using (var stream = new MemoryStream ()) {
        
        message.WriteTo (stream);
        rawMessage = Convert.ToBase64String (stream.GetBuffer (), 0, (int) stream.Length)
            .Replace ('+', '-')
            .Replace ('/', '_')
            .Replace ("=", "");
    }
    var gmailMessage = new Google.Apis.Gmail.v1.Data.Message
                    {  Raw = rawMessage };
