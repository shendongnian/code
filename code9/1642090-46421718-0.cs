        static public string CsvQuote(this string text)
        {
            if (text == null)
            {
                return string.Empty;
            }
            bool containsQuote = false;
            bool containsComma = false;
            bool containsNewline = false;
            bool containsCR = false;
            int len = text.Length;
            for (int i = 0; i < len && (containsComma == false || containsQuote == false); i++)
            {
                char ch = text[i];
                if (ch == '"')
                {
                    containsQuote = true;
                }
                else if (ch == ',')
                {
                    containsComma = true;
                }
                else if (ch == '\r')
                {
                    containsCR = true;
                }
                else if (ch == '\n')
                {
                    containsNewline = true;
                }
            }
            bool mustQuote = containsComma || containsQuote || containsCR || containsNewline;
            if (containsQuote)
            {
                text = text.Replace("\"", "\"\"");
            }
            if (mustQuote)
            {
                return "\"" + text + "\"";  // Quote the cell and replace embedded quotes with double-quote
            }
            else
            {
                return text;
            }
        }
