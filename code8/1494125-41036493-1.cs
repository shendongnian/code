    string Example = "OK OR LOK";
    // Replace "OK" which is not preceded by any word character
    string res = Regex.Replace(Example, @"(?<!\w)OK", "true");
    string res2 = Regex.Replace(res, @"(?<!\w)LOK", "false");
    Console.WriteLine(res);
    Console.WriteLine(res2);
