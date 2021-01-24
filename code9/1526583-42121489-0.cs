    private static void WriteCustomDocumentProperty(Workbook workbook, string name, string value)
    {
        var numParts = value.Length / 255 + (value.Length % 255 != 0 ? 1 : 0);
        var parts = Enumerable.Range(0, numParts).Select(i => value.Substring(i * 255, Math.Min(255, value.Length - i * 255))).ToArray();
        dynamic customDocumentProperties = workbook.CustomDocumentProperties;
        for (var i = 0; i < numParts; ++i)
            customDocumentProperties.Add(name + "." + i, false, MsoDocProperties.msoPropertyTypeString, parts[i]);
        customDocumentProperties.Add(name + ".Count", false, MsoDocProperties.msoPropertyTypeNumber, numParts);
    }
    private static string ReadCustomDocumentProperty(Workbook workbook, string name)
    {
        dynamic customDocumentProperties = workbook.CustomDocumentProperties;
        var numParts = Convert.ToInt32(customDocumentProperties[name + ".Count"].Value);
        var value = new StringBuilder();
        for (var i = 0; i < numParts; ++i)
            value.Append(customDocumentProperties[name + "." + i].Value);
        return value.ToString();
    }
