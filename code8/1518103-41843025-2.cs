    List<string> matches = new List<string>();
    foreach (string s in new string[] { "Fizz", "Buzz", "Foo", "Bar", "eeeeeeeeeo", "kjkjsh", "iousadh", "kjlsadh", "jfsfs", "sdfs" })
    {
        if (Regex.IsMatch(sample, "[,.:]" + s + "[?!]", RegexOptions.Compiled))
        {
            matches.Add(s);
        }
    }//890ms
