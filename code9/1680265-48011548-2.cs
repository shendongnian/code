    public static class JTokenExtensions
    {
        const string XsiNamespace = @"http://www.w3.org/2001/XMLSchema-instance";
        readonly static string XmlNullValue = System.Xml.XmlConvert.ToString(true);
        public static JToken ReplaceXmlNilObjectsWithNull(this JToken root)
        {
            return root.ReplaceXmlNilObjects(t => JValue.CreateNull());
        }
        public static JToken ReplaceXmlNilObjects(this JToken root, Func<JToken, JToken> getReplacement)
        {
            var query = from obj in root.DescendantsAndSelf().OfType<JObject>()
                        where obj.Properties().Any(p => p.IsNilXmlTrueProperty())
                        select obj;
            foreach (var obj in query.ToList())
            {
                var replacement = getReplacement(obj);
                if (obj == root)
                    root = replacement;
                if (obj.Parent != null)
                    obj.Replace(replacement);
            }
            return root;
        }
        static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            // Small wrapper adding this method to all JToken types.
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new[] { node };
        }
        static string GetXmlNamespace(this JProperty prop)
        {
            if (!prop.Name.StartsWith("@"))
                return null;
            var index = prop.Name.IndexOf(":");
            if (index < 0 || prop.Name.IndexOf(":", index+1) >= 0)
                return null;
            var ns = prop.Name.Substring(1, index - 1);
            if (string.IsNullOrEmpty(ns))
                return null;
            var nsPropertyName = "@xmlns:" + ns;
            foreach (var obj in prop.AncestorsAndSelf().OfType<JObject>())
            {
                var nsProperty = obj[nsPropertyName];
                if (nsProperty != null && nsProperty.Type == JTokenType.String)
                    return (string)nsProperty;
            }
            return null;
        }
        static bool IsNilXmlTrueProperty(this JProperty prop)
        {
            if (prop == null)
                return false;
            if (!(prop.Value.Type == JTokenType.String && (string)prop.Value == "true"))
                return false;
            if (!(prop.Name.StartsWith("@") && prop.Name.EndsWith(":nil")))
                return false;
            var ns = prop.GetXmlNamespace();
            return ns == XsiNamespace;
        }
    }
