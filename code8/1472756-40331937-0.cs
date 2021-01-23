    public static string Transform(string input, Dictionary<string, string> replacements)
        {
            string finalString = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (replacements.ContainsKey(input[i].ToString()))
                {
                    finalString = finalString + replacements[input[i].ToString()];
                }
                else
                {
                    finalString = finalString + input[i].ToString();
                }
            }
            return finalString;
        }
