    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CsvDataAttribute : DataAttribute
    {
        private readonly string _fileName;
        public CsvDataAttribute(string fileName)
        {
            _fileName = fileName;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var pars = testMethod.GetParameters();
            var parameterTypes = pars.Select(par => par.ParameterType).ToArray();
            using (var csvFile = new StreamReader(_fileName))
            {
                csvFile.ReadLine();// Delimiter Row: "sep=,". Comment out if not used
                csvFile.ReadLine(); // Headings Row. Comment out if not used
                string line;
                while ((line = csvFile.ReadLine()) != null)
                {
                    var row = line.Split(',');
                    yield return ConvertParameters((object[])row, parameterTypes);
                }
            }
        }
        private static object[] ConvertParameters(IReadOnlyList<object> values, IReadOnlyList<Type> parameterTypes)
        {
            var result = new object[parameterTypes.Count];
            for (var idx = 0; idx < parameterTypes.Count; idx++)
            {
                result[idx] = ConvertParameter(values[idx], parameterTypes[idx]);
            }
            return result;
        }
        private static object ConvertParameter(object parameter, Type parameterType)
        {
            return parameterType == typeof(int) ? Convert.ToInt32(parameter) : parameter;
        }
    }
