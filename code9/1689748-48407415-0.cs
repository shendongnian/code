    using System.Text.RegularExpressions;
    ...
    Regex leadingTrailingAsterisks = new Regex("(^\*)|(\*$)");
    private string RemoveAllowedAsterisks(string pattern)
    {
        return leadingTrailingAsterisks.Replace(input, "");
    }
