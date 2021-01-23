    public class JsonUtils
    {
        public static string HtmlEncodeJTokenStrings(string jsonString)
        {
            var reconstruct = JToken.Parse(jsonString);
            var stack = new Stack<JToken>();
            stack.Push(reconstruct);
            
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.Type == JTokenType.String)
                {
                    var valueItem = item as JValue;
                    if(valueItem == null)
                        continue;
                    var value = valueItem.Value<string>();
                    valueItem.Value = AntiXssEncoder.HtmlEncode(value, true);
                }
                foreach (var child in item.Children())
                {
                    stack.Push(child);
                }
            }
            return reconstruct.ToString();
        }
    }
