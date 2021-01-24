    public static IEnumerable<AnalysisCodeWithValue> ExtractProperties(this Customer customer, 
        IEnumerable<PropertyInfo> properties)
    {
        // TODO: add Argument NULL checks
        foreach (PropertyInfo property in properties)
        {
            yield return new AnalysisCodeWithValues()
            {
                 Name = property.Name,
                 Value = property.GetValue(customer).ToString(),
            };
        }
    }
