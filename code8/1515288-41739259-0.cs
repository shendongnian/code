    public string MeaningfulMethodName(XElement propertyGroup, string groupName, string propertyName)
    {
        var codeAnalysis = (from doc in propertyGroup?.Descendants(propertyName) select doc).ToArray();
        if (codeAnalysis.Length == 0)
        {
            return $"{groupName}: {propertyName} is missing.";
        }
        var allOk = codeAnalysis.All(n => n.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase));
        return allOk ? null : $"{groupName}: {propertyName} has wrong state.";
    }
