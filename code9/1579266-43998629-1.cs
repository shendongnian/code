    // get the string into a char array, one character per element
    char[] step1 = example.ToCharArray();
    // Now let's get this into a collection of string values
    IEnumerable<string> step2 = step1.Select(c => c.ToString());
    // which we finally turn into an array of strings
    string[] exampel2 = step2.ToArray();
