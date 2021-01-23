    public static string RemoveSensitiveProperties(string json, IEnumerable<Regex> regexes)
    {
        JToken token = JToken.Parse(json);
        RemoveSensitiveProperties(token, regexes);
        return token.ToString();
    }
    public static void RemoveSensitiveProperties(JToken token, IEnumerable<Regex> regexes)
    {
        if (token.Type == JTokenType.Object)
        {
            foreach (JProperty prop in token.Children<JProperty>().ToList())
            {
                bool removed = false;
                foreach (Regex regex in regexes)
                {
                    if (regex.IsMatch(prop.Name))
                    {
                        prop.Remove();
                        removed = true;
                        break;
                    }
                }
                if (!removed)
                {
                    RemoveSensitiveProperties(prop.Value, regexes);
                }
            }
        }
        else if (token.Type == JTokenType.Array)
        {
            foreach (JToken child in token.Children())
            {
                RemoveSensitiveProperties(child, regexes);
            }
        }
    }
