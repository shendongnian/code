    // Dictionary<string, string> - actual keys are strings
    Dictionary<string, string> keys = new Dictionary<string, string>();
    keys.Add("a", "23");
    keys.Add("A", "95");
    keys.Add("d", "12");
    keys.Add("D", "69");
    string result = string.Concat(text.Select(c => keys[c.ToString()]));
