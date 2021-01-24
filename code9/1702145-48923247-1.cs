    foreach (PropertyInfo property in properties)
    {
        string stringValue = property.GetValue(customer)?.ToString();
        if (!String.IsNullOrEmpty(stringValue))
        {
            yield return new AnalysisCodeWithValues()
            {
                 Name = property.Name,
                 Value = stringValue,
            };
        }
    }
