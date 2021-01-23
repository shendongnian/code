    string str1 = "0";
    string str2 = "+";
    Console.WriteLine(Math.Sign(string.Compare(str1, str2, StringComparison.InvariantCulture))); // output : 1
    Console.WriteLine(Math.Sign(string.Compare(str1, str2, StringComparison.Ordinal)));          // output : 1
    string str3 = "01";
    string str4 = "+1";
    Console.WriteLine(Math.Sign(string.Compare(str3, str4, StringComparison.InvariantCulture))); // output : 1
    Console.WriteLine(Math.Sign(string.Compare(str3, str4, StringComparison.Ordinal)));          // output : 1
