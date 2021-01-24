    class JsonParser
    {
        public static string Parse(MyJsonObject jsonObject)
        {
            string parse = "{";
            parse += string.Join(",", jsonObject.Columns.Select(column => $"\"{column}\": \"\""));
            if (!string.IsNullOrEmpty(jsonObject.ChildName))
            {
                parse += $",\"{jsonObject.ChildName}\":";
                parse += $"[{string.Join(",", jsonObject.Children.Select(Parse))}]";
            }
            parse += "}";
            return parse;
        }
    }
