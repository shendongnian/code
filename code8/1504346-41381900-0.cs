     public static class StringParser
    {
        public static List<string> ParseExpression(string expression)
        {
            //expression = System.Text.RegularExpressions.Regex.Replace(expression, @"\s+", " ");
            string word = string.Empty;
            int i = 0;
            List<string> list = new List<string>();
            while (i < expression.Length)
            {
                if (expression[i] == ' ')
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        list.Add(word);
                        word = string.Empty;
                    }
                    i++;
                    continue;
                }
                if (expression[i] == '=')
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        list.Add(word);
                    }
                    word = new string(expression[i], 1);
                    list.Add(word);
                    word = string.Empty;
                    i++;
                    continue;
                }
                if (expression[i] == '<')
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        list.Add(word);
                    }
                    word = new string(expression[i], 1);
                    i++;
                    word += expression[i];
                    list.Add(word);
                    word = string.Empty;
                    i++;
                    continue;
                }
                word += expression[i];
                i++;
                if (!string.IsNullOrEmpty(word) && i == expression.Length)
                {
                    list.Add(word);
                }
            }
            return list;
        }
    }
