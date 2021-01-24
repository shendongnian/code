    public static List<string> LastFieldValues(XmlReader reader)
    {
        var query = reader.ReadNestedElements("field", "value")
            .Select(l => l.LastOrDefault())
            .Where(v => v != null)
            .Select(v => (string)v);
        return query.ToList();
    }
