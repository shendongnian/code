    class MyClass
    {
 
        // these are dynanically defined elsewhere.
        const string personXPath = "/Doc/Person";
        const string nameXPath = "/Doc/Name[@id=current()/@nameid]"; 
        XElement _node;
        void ParseXDocument(XDocument doc)
        {
            foreach (var personElement in doc.XPathSelectElements(personXPath))
            {
                _node = personElement; // my actual code is a bit cleaner
                var nameElement = personElement.XPathSelectElement(PreParse(nameXPath));
                Console.WriteLine(nameElement.Value);
            }
        }
        /// <summary>
        /// Pre-evaluates calls to current()
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private string PreParse(string xpath)
        {
            var sb = new StringBuilder();
            foreach (var part in Tokenize(xpath))
            {
                if (part.Trim().StartsWith("current()"))
                {
                    var query = part.Replace("current()", ".");
                    sb.Append("'")
                        .Append(EvaluateXPath(query))
                        .Append("'");
                }
                else
                {
                    sb.Append(part);
                }
            }
            return sb.ToString();
        }
        private IEnumerable<string> Tokenize(string path)
        {
            var begin = 0;
            for (var i = 0; i < path.Length; i++)
            {
                if ("[=]".Contains(path[i]))
                {
                    yield return path.Substring(begin, i - begin);
                    yield return path[i].ToString();
                    begin = i + 1;
                }
            }
            yield return path.Substring(begin);
        }
        private string EvaluateXPath(string xpath)
        {
            var result = _node.XPathEvaluate(xpath);
            if (result is IEnumerable)
                foreach (var node in (IEnumerable)result)
                    return (node as XElement)?.Value ?? (node as XAttribute).Value;
            return string.Format(CultureInfo.InvariantCulture, "{0}", result);
        }
    }
