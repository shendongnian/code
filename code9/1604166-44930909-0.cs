    foreach (string s in sPattern)
        {
            if (Regex.IsMatch(answer, s, RegexOptions.IgnoreCase))
            {
                sPattern.Remove(s);
                break;
            }
        }
