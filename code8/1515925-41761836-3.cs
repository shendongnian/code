    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation]
        public List<TestParameters> GetTestParameters(Table table)
        {
            return table.Rows.Select(row => new TestParameters
            {
                // string prop
                ParameterName = row["ParameterName"],
                // int prop
                Value = !String.IsNullOrEmpty(row["Value"]) ? Int32.Parse(row["Value"]) : 0,
                // bool prop
                Mandatory = row["Mandatory"]?.ToLowerInvariant() == "true"
                // TODO: other properties
            }).ToList();
        }
    }
