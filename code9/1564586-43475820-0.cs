    foreach (string s in TestTokens)
    {
        //Is this item alpha-only? (Checking this before alphanumeric)
        if (!bHasAlpha && Regex.IsMatch(s, @"^[a-zA-Z]+$")) // Add !bHasAlpha to skip chekcing if you have found one
            bHasAlpha = true;
        //Is this item alphanumeric?
        else if (Regex.IsMatch(s, @"^[a-zA-Z0-9]+$"))
            bHasAlphaNum = true;
    }
