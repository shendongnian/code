    public static Dictionary<string, string> GetFormFieldNames(string pdfPath)
    {
        var fields = new Dictionary<string, string>();
    
        foreach (var entry in reader.AcroFields.Fields)
        {
            fields.Add(entry.*use intellisense here*, string.Empty);
        }
    
        return fields;
    }
