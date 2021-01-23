    public class ParserOutput
    {
        public string Name { get; }
        public string Type { get; }
        public IEnumerable<Tuple<string, string>> KeyValuePairs { get; }
        public bool ContainsKeyValuePairs { get; }
        public bool HasErrors { get; }
        public IEnumerable<string> ErrorDescriptions { get; }
        public ParserOutput(string name, string type, IEnumerable<Tuple<string, string>> keyValuePairs, IEnumerable<string> errorDescriptions)
        {
            Name = name;
            Type = type;
            KeyValuePairs = keyValuePairs;
            ContainsKeyValuePairs = keyValuePairs.FirstOrDefault()?.Item2?.Length > 0;
            ErrorDescriptions = errorDescriptions;
            HasErrors = errorDescriptions.Any();
        }
    }
    public class CustomParser
    {
        private const char forwardSlash = '/';
        private const char colon = ':';
        private const char space = ' ';
        private const char equals = '=';
        private const char comma = ',';
        StringBuilder buffer = new StringBuilder();
        public ParserOutput Parse(string input)
        {
            var diagnosticsBag = new Queue<string>();
            using (var enumerator = input.GetEnumerator())
            {
                var name = ParseToken(enumerator, forwardSlash, diagnosticsBag);
                var type = ParseToken(enumerator, colon, diagnosticsBag);
                var keyValuePairs = ParseListOrKey(enumerator, diagnosticsBag);
                if (name.Length == 0)
                {
                    diagnosticsBag.Enqueue("Input has incorrect format. Name could not be parsed.");
                }
                if (type.Length == 0)
                {
                    diagnosticsBag.Enqueue("Input has incorrect format. Type could not be parsed.");
                }
                if (!keyValuePairs.Any() ||
                    input.Last() == comma /*trailing comma is error?*/)
                {
                    diagnosticsBag.Enqueue("Input has incorrect format. Key / Value pairs could not be parsed.");
                }
                return new ParserOutput(name, type, keyValuePairs, diagnosticsBag);
            }
        }
        private string ParseToken(IEnumerator<char> enumerator, char separator, Queue<string> diagnosticsBag)
        {
            buffer.Clear();
            var allowWhitespaces = separator != forwardSlash && separator != colon;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == space && !allowWhitespaces)
                {
                    diagnosticsBag.Enqueue($"Input has incorrect format. {(separator == forwardSlash ? "Name" : "Type")} cannot contain whitespaces.");
                }
                else if (enumerator.Current != separator)
                {
                    buffer.Append(enumerator.Current);
                }
                else
                    return buffer.ToString();
            }
            return buffer.ToString();
        }
        private IEnumerable<Tuple<string, string>> ParseListOrKey(IEnumerator<char> enumerator, Queue<string> diagnosticsBag)
        {
            buffer.Clear();
            var isList = false;
            while (true)
            {
                var key = ParseToken(enumerator, equals, diagnosticsBag);
                var value = ParseToken(enumerator, comma, diagnosticsBag);
                if (key.Length == 0)
                    break;
                yield return new Tuple<string, string>(key, value);
                if (!isList && value.Length != 0)
                {
                    isList = true;
                }
                else if (isList && value.Length == 0)
                {
                    diagnosticsBag.Enqueue($"Input has incorrect format: malformed [key / value] list.");
                }
            }
        }
    }
