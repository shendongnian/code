    string res = Regex.Replace(input, @"(\d\D|\D\d)", new MatchEvaluator(
        m => {
            char a = m.Groups[1].Value[0], b = m.Groups[1].Value[1];
            if (char.IsWhiteSpace(a) || char.IsWhiteSpace(b))
                return m.Groups[1].Value;
            return a + " " + b;
    }));
