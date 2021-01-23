    void Parse(string message, Dictionary<string, MapAttribute> fieldMapping)
    {
        string[] messageContent = message.Split(':');
        var question = new Question();
        for (int index = 0; index < messageContent.Length; index++)
        {
            string field = messageContent[index];
            MapAttribute mapping = fieldMapping[field];
            index++;
            mapping.SetValue(question, messageContent[index]);
        }
    }
