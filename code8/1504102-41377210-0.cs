    var str = "Regex.Replace is extremely FAST for simple replacements like that";
    var compiled = new Regex(@"\bfast\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    var interpreted = new Regex(@"\bfast\b", RegexOptions.IgnoreCase);
    var start = DateTime.UtcNow;
    for (int i = 0; i < 1000000; i++)
    {
        // Comment out all but one of these:
        str.Replace("FAST", "12345"); // PC #1: 208 ms, PC #2: 339 ms
        compiled.Replace(str, "12345"); // 1100 ms, 2708 ms
        interpreted.Replace(str, "12345"); // 788 ms, 2174 ms
        Regex.Replace(str, @"\bfast\b", "12345", RegexOptions.IgnoreCase); // 1076 ms, 3138 ms
    }
    Console.WriteLine((DateTime.UtcNow - start).TotalMilliseconds);
