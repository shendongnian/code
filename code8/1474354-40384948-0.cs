    public static string Truncate(string text, int startIndex, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return text;
            int remaining = maxLength;
            int index = startIndex;
            while (remaining > 0 && index<text.Length)
            {
                if (text[index] == '\n')
                {
                    remaining -= CHARS_PER_NEWLINE;
                }
                else
                {
                    remaining--;
                }
                index++;
            }
            return text.Substring(startIndex, index - startIndex) + '-';
        }
