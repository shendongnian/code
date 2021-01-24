    public static void Main(string[] args)
    {
        const string testHtml = @"<head><title>&#xd83d;&#xdc4d;</title></head><body>&nbsp;&nbsp;&nbsp;</body>";
        var output = Remove(testHtml);
        Console.WriteLine(output);
        Console.Read();
    }
    
    private static string Remove(string input)
    {
        var regex = new Regex("\\&#.*?\\;");
        var output = regex.Replace(input, string.Empty);
        return output;
    }
