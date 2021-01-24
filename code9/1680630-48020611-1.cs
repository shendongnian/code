    public string GetPrintReadyString(string originalString)
    {
        string result = ""
        for (var i = 0; i < originalString.Length; i += 7)
          result += (originalString.Substring(i, Math.Min(7, originalString.Length - i)) + Environment.NewLine);
        return result;
    }
