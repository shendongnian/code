        static string toCamel(string input)
        {
            StringBuilder sb = new StringBuilder();
            int i;
            for (i = 0; i < input.Length; i++)
            {
                if ((i == 0) || (i > 0 && input[i - 1] == '_'))
                    sb.Append(char.ToUpper(input[i]));
                else
                    sb.Append(char.ToLower(input[i]));
            }
            return sb.ToString();
        }
