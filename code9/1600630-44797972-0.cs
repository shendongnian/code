    var list = new List<string> { "VB0.0", "VB20479.0", "VB20479.7", "VB20480.0", "VB010000.0", "VB0.8", "VBx.y" };
    string pattern = @"(\d+)\.(\d+)";
    foreach (var input in list)
    {
        var m = Regex.Match(input, pattern);
        if (m.Success)
        {
            string value1 = m.Groups[1].Value;
            string value2 = m.Groups[2].Value;
            bool result = value1.Length <= 5 && int.Parse(value1) <= 20479
                       && value2.Length <= 1 && int.Parse(value2) <= 7;
            Console.WriteLine(result);
        }
        else Console.WriteLine(false);
    }
