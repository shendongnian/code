    static void Main(string[] args)
    {
        string invisibleChar = "\u200C";
        string[] samples = { "Test_test", "Test2_blah", "Test3_" + invisibleChar };
        string[] splitSample = samples[2].Split(new char[] { '_' }, 2);
        // Prints "Test3_" (or "Test3_?" if you use Console.Write).
        Debug.Print(samples[2]);
        Debug.Print(splitSample.Length.ToString());     // 2
        if (!string.IsNullOrWhiteSpace(splitSample[1]))
        {
            Debug.Print(splitSample[1].Length.ToString());    // 1
            // Prints "" (or "?" in Console).
            Debug.Print(splitSample[1]);
            var hex = string.Join("", splitSample[1].Select(c => ((int)c).ToString("X2")));
            // Prints "200C"
            Debug.Print(hex);
        }
        Console.ReadLine();
    }
