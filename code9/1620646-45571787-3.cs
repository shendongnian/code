    List<string> GetVals2Lol(string keyword, string input)
    {
        var vals = new List<string>();
        int startIndex = input.IndexOf("[");
        while (startIndex >= 0)
        {
            var newValue = "";
            if (startIndex >= 0 && startIndex < input.Length - 1)
            {
                var squareKey = input.Substring(startIndex + 1).Trim();
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
                            {
                                newValue = quotedVal.Substring(1, endQuoteIndex - 1);
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                vals.Add(newValue);
                startIndex = input.IndexOf("[", input.IndexOf(newValue, startIndex) + newValue.Length);
            }
            else
                startIndex = -1;
        }
        return vals;
    }
