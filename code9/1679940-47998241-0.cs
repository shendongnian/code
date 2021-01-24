    public class TextFieldParser : StreamReader, IDisposable
    {
        int iToken = 1;
        bool quoted = false;
        char[] delimiters;
        string curLine;
        public TextFieldParser(string path) : base(path) { }
        public TextFieldParser(Stream stream) : base(stream) { }
        public string[] ReadFields()
        {
            curLine = ReadLine();
            return GetFields();
        }
        public void SetDelimiters(string delim)
        {
            delimiters = delim.ToCharArray();
        }
        public string[] GetFields()
        {
            if (delimiters == null || delimiters.Length == 0)
                throw new Exception($"{GetType().Name} requires delimiters be defined to identify fields.");
            if (!hasFieldsEnclosedInQuotes)
            {
                return curLine.Split(delimiters);
            }
            else
            {
                var token = (char)iToken;
                var sb = new StringBuilder();
                // Go through the string and change delimiters to token
                // ignoring them if within quotes if indicated
                for (int c = 0; c < curLine.Length; c++)
                {
                    var qc = curLine[c];
                    if (hasFieldsEnclosedInQuotes && qc == '"')
                    {
                        quoted = !quoted;
                        continue;
                    }
                    else if (!quoted)
                    {
                        // Replace the delimiters with token
                        for (int d = 0; d < delimiters.Length; d++)
                        {
                            if (qc == delimiters[d])
                            {
                                qc = token;
                                break;
                            }
                        }
                    }
                    sb.Append(qc);
                }
                return sb.ToString().Split(token);
            }
        }
        private bool hasFieldsEnclosedInQuotes = false;
        public bool HasFieldsEnclosedInQuotes
        {
            get { return hasFieldsEnclosedInQuotes; }
            set { hasFieldsEnclosedInQuotes = value; }
        }
        public bool EndOfData
        {
            get { return EndOfStream; }
        }
