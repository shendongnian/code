    private static string Increase(string productNo)
    {
        // This is a regex to split it into to groups.
        var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
        // Match the input string for the regex.
        var match = numAlpha.Match(productNo);
        // Get the alphabetical part.
        var alpha = match.Groups["Alpha"].Value;
        // Get the numeric part.
        int num = int.Parse(match.Groups["Numeric"].Value);
        // Add +1
        num++;
        // Combine the alphabetical part with the increased number, but use PadLeft to maintain the padding (leading zeros).
        var newString = string.Format("{0}{1}", alpha, num.ToString().PadLeft(match.Groups["Numeric"].Value.Length, '0'));
        return newString;
    }
    Console.WriteLine(Increase("DTS00008"));
    Console.WriteLine(Increase("DTS00010"));
    Console.WriteLine(Increase("DTS00020"));
    Console.WriteLine(Increase("DTS00099"));
    Console.WriteLine(Increase("PRODUCT0000009"));
    Console.WriteLine(Increase("PRODUCT0000001"));
