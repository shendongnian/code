    static string ReverseString(string s)
        {
            var sb = new StringBuilder();
            var words = s.Split(' ');
            foreach (var word in words)
            {
                var toAdd = new char();
                for (var i = word.Length -1; i >= 0; i--)
                {
                    if (char.IsPunctuation(word[i]))
                    {
                        toAdd = word[i];
                    }
                    else
                    {
                        sb.Append(word[i]);
                    }
                }
                if (toAdd != new char())
                {
                    sb.Append(toAdd);
                }
                sb.Append(" ");
            }
            return sb.ToString();
        }
