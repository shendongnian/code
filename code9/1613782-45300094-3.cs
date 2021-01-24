    public int Compare(string x, string y)
    {
        var regex = new Regex(@"([a-z]+)(\.[0-9]+)?(\.[0-9]+)?", RegexOptions.IgnoreCase);
        var matchX = regex.Match(x);
        var matchY = regex.Match(y);
        if (!matchX.Success || !matchY.Success)
            return string.Compare(x, y);
        int result = string.Compare(matchX.Groups[1].Value, matchY.Groups[1].Value);
        if (result != 0)
            return result;
        if (matchX.Groups.Length == 2) // no digits in first
        {
            if (matchY.Groups.Length == 2) // no digits in second either
                return 0; // equal strings
            else
                return -1; // second has digits, first not
        }
        else // first has digits
        {
            // I assume that both digit groups are present or none
            if (matchY.Groups.Lenght == 2) // first has digits, second not
                return 1;
            else // both have digits
            {
                int xDigit1 = int.Parse(matchX.Groups[2].Value.Substring(1)); // substring to skip '.'
                int xDigit2 = int.Parse(matchX.Groups[3].Value.Substring(1)); // substring to skip '.'
                int yDigit1 = int.Parse(matchY.Groups[2].Value.Substring(1)); // substring to skip '.'
                int yDigit2 = int.Parse(matchY.Groups[3].Value.Substring(1)); // substring to skip '.'
                if (xDigit1 != yDigit1)
                    return int.Compare(xDigit1, yDigit1);
                // first digits are equal here
                return int.Compare(xDigit2, yDigit2);
            }
        }
    }
