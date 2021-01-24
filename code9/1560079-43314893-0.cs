    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
    private string InternalPluralize(string word)
    {
        // other stuff
        if (suffixWord.EndsWith("o", true, this.Culture) || suffixWord.EndsWith("s", true, this.Culture))
        {
            return prefixWord + suffixWord + "es";
        }
        // other stuff
    }
