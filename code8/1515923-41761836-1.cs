    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation]
        public List<TestParameters> GetTestParameters(Table table)
        {
            return table.Rows.Select(row => new TestParameters
            {
                // string prop
                ParameterName = row.GetColumn("ParameterName"),
                // int prop
                Value = !String.IsNullOrEmpty(row.GetColumn("Value")) ? Int32.Parse(row.GetColumn("Value")) : 0,
                // bool prop
                Mandatory = row.GetColumn("Mandatory")?.ToLowerInvariant() == "true"
                // TODO: other properties
            }).ToList();
        }
    }
