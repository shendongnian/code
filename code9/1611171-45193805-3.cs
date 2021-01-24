        public static IEnumerable<string> Split(string inputText, int maxLength)
        {
            int i = 0;
            while (i + maxLength < inputText.Length)
            {
                var lastIndexofUnderScore = inputText.LastIndexOf('_', i + maxLength);
                var lastIndexofSpace = inputText.LastIndexOf(' ', i + maxLength);
                var index = Math.Min(lastIndexofSpace, lastIndexofUnderScore);
                if (index <= 0) 
                {
                    index = maxLength;
                }
                yield return inputText.Substring(i, index - i).Trim();
                i = index + 1;
            }
            yield return inputText.Substring(i).Trim();
        }
