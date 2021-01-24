     public static IEnumerable<AnalysisCodeWithValue> ExtractProperties(this Customer customer, 
        IEnumerable<KeyValuePair<string, Func<Customer, object>> delegates)
    {
        foreach (var requestedProperty in delegates)
        {
            var propertyValue = requestedProperty.Value(customer);
            string stringValue = propertyValue?.ToString();
            if (!String.IsNullOrEmpty(stringValue))
            {
                yield return new AnalysisCodeWithValues()
                {
                     Name = requestedProperty.Key,
                     Value = stringValue,
                };
            }
        }
    }
