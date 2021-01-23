    string PrepareForSendKeys(string input)
    {
        var specialChars = "+^%~{}";
        var c1 = "[BRACEOPEN]";
        var c2 = "[BRACECLOSE]";
        specialChars.ToList().ForEach(x =>
        {
            input = input.Replace(x.ToString(),
                string.Format("{0}{1}{2}", c1, x.ToString(), c2));
        });
        input = input.Replace(c1, "{");
        input = input.Replace(c2, "}");
        return input;
    }
