    string GetVal2Lol(string keyword, string input)
    {
        var squareIndex = input.IndexOf("[");
        if (squareIndex >= 0 && squareIndex < input.Length - 1)
        {
            var squareKey = input.Substring(squareIndex + 1).Trim();
            if (squareKey.StartsWith(keyword))
            {
                var squareAssign = squareKey.Substring(keyword.Length).Trim();
                var assignOp = StartsWithWhich(squareAssign, "=", "+=", "-=", "*=", "/=", "^=", "%=");
                if (!string.IsNullOrWhiteSpace(assignOp))
                {
                    var quotedVal = squareAssign.Substring(assignOp.Length).Trim();
                    if (quotedVal.StartsWith("\""))
                    {
                        var endQuoteIndex = quotedVal.IndexOf('"', 1);
                        if (endQuoteIndex > 0)
                            return quotedVal.Substring(1, endQuoteIndex - 1);
                    }
                }
            }
        }
        return "";
    }
