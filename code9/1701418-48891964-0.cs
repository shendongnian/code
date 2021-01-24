    private int Move(string text, int current, int line, int position)
    {
        while (current < text.Length && (line > 1 || position > 1))
        {
            if (text[current] == '\n')
            {
                if (line == 1)
                    return -1;
                line--;
            }
            else if (line == 1)
            {
                position--;
            }
            current++;
        }
        return current;
    }
    private (bool jsonParseResult, BaseTextPart part, int newIndex) TryParseJson(string text, int current)
    {
        try
        {
            string textPart = text.Substring(current);
            JObject obj = JObject.Parse(textPart);
            return (true, new JsonTextPart(obj), text.Length);
        }
        catch (JsonReaderException e)
        {
            int end = Move(text, current, e.LineNumber, e.LinePosition);
            try
            {
                string textPart = text.Substring(current, end - current);
                JObject obj = JObject.Parse(textPart);
                return (true, new JsonTextPart(obj), end);
            }
            catch (JsonReaderException)
            {
                return (false, null, 0);
            }
        }
    }
    private (bool xmlParseResult, BaseTextPart part, int newIndex) TryParseXml(string text, int current)
    {
        XmlDocument doc = new XmlDocument();
        try
        {
            string textPart = text.Substring(current);
            doc.Load(new StringReader(textPart));    
            return (true, new XmlTextPart(doc), text.Length);
        }
        catch (XmlException e)
        {
            int end = Move(text, current, e.LineNumber, e.LinePosition);
            try
            {
                string textPart = text.Substring(current, end - current);
                doc.Load(new StringReader(textPart));
                return (true, new XmlTextPart(doc), end);
            }
            catch (XmlException)
            {
                return (false, null, 0);
            }
        }
    }
    private List<BaseTextPart> Parse(string text)
    {
        var result = new List<BaseTextPart>();
        int current = 0;
        StringBuilder buffer = new StringBuilder();
        while (current < text.Length)
        {
            if (text[current] == '{')
            {
                (bool jsonParseResult, BaseTextPart part, int newIndex) = TryParseJson(text, current);
                if (jsonParseResult)
                {
                    if (buffer.Length > 0)
                    {
                        result.Add(new SimpleTextPart(buffer.ToString()));
                        buffer.Clear();
                    }
                    result.Add(part);
                    current = newIndex;
                    continue;
                }
            }
            if (text[current] == '<')
            {
                (bool xmlParseResult, BaseTextPart part, int newIndex) = TryParseXml(text, current);
                if (xmlParseResult)
                {
                    if (buffer.Length > 0)
                    {
                        result.Add(new SimpleTextPart(buffer.ToString()));
                        buffer.Clear();
                    }
                    result.Add(part);
                    current = newIndex;
                    continue;
                }
            }
            buffer.Append(text[current]);
            current++;
            continue;
        }
        if (buffer.Length > 0)
        {
            result.Add(new SimpleTextPart(buffer.ToString()));
            buffer.Clear();
        }
        return result;
    }
