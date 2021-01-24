    private static void WriteCustomDocumentProperty(Workbook workbook, string name, string value)
    {
        dynamic customDocumentProperties = workbook.CustomDocumentProperties;
        var numParts = value.Length/255 + (value.Length%255 != 0 ? 1 : 0);
        for (var i = 0; i < numParts; ++i)
        {
            var part = value.Substring(i*255, Math.Min(255, value.Length - i*255));
            customDocumentProperties.Add(name + "." + i, false, MsoDocProperties.msoPropertyTypeString, part);
        }
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
