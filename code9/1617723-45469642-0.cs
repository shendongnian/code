    public static class JsonExtensions
    {
        public static TJToken Convert<TJToken>(this TJToken data) where TJToken : JToken
        {
            var queue = new Queue<JToken>();
            foreach (var child in data.Children())
            {
                queue.Enqueue(child);
            }
            while (queue.Count > 0)
            {
                var token = queue.Dequeue();
                if (token is JProperty)
                {
                    var p = (JProperty)token;
                    if (p.Value.Type != JTokenType.Object)
                    {
                        var value = p.Value;
                        // Remove the value from its parent before adding it to a new parent, 
                        // to prevent cloning.
                        p.Value = null;
                        var replacement = new JProperty(
                            string.Format("{0}.{1}", p.Name, value.Type),
                            value
                        );
                        token.Replace(replacement);
                        token = replacement;
                    }
                }
                foreach (var child in token.Children())
                {
                    queue.Enqueue(child);
                }
            }
            return data;
        }
    }
