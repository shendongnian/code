    var values = new List<string>();
    string input = "+hello-ali!56*89";
    var delimiters = new char[] { '+', '-', '*', '!' };
    //split the strings using the delimiters, eliminate empty strings
    var tempValues = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    var curChar = 0;
    // iterate through the input string finding your original strings
    // include the delimiter
    foreach (var val in tempValues)
    {
        var matchCharStart = input.IndexOf(val, curChar,   StringComparison.Ordinal);
        if (matchCharStart <= 0) continue;
            values.Add(input.Substring(matchCharStart - 1, val.Length + 1));
            if (matchCharStart > 0) curChar = matchCharStart + val.Length;
        }
    }
