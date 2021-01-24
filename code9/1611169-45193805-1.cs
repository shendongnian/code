        public static IEnumerable<string> Split(string inputText, int maxLength)
        {
            int i = 0;
            while (i + maxLength < inputText.Length)
            {
                var index = inputText.LastIndexOf(' ', i + maxLength);
                if (index <= 0) 
                {
                    index = maxLength;
                }
                yield return inputText.Substring(i, index - i);
                i = index + 1;
            }
            yield return inputText.Substring(i);
        }
