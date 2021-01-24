    public static string ReplaceFraction(string inputString)
    {
        string pattern = @"(\d+)(/)(\d+)";
        return System.Text.RegularExpressions.Regex.Replace(inputString, pattern, (match) =>
        {
            decimal numerator = int.Parse(match.Groups[1].Value);
            decimal denominator = int.Parse(match.Groups[3].Value);
            return (numerator / denominator).ToString();
        });
    }
