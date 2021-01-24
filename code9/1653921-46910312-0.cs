    private static Tuple<string, object[]> PrepareArguments(string storedProcedure, object parameters)
        {
            var parameterNames = new List<string>();
            var parameterParameters = new List<object>();
 
            if (parameters != null)
            {
                foreach (PropertyInfo propertyInfo in parameters.GetType().GetProperties())
                {
                    string name = string.Format("@{0}", propertyInfo.Name);
                    object value = propertyInfo.GetValue(parameters, null);
 
                    parameterNames.Add(name);
                    parameterParameters.Add(new SqlParameter(name, value ?? DBNull.Value));
                }
            }
 
            if (parameterNames.Count > 0)
                storedProcedure = string.Format("{0} {1}", storedProcedure, string.Join(", ", parameterNames));
 
            return new Tuple<string, object[]>(storedProcedure, parameterParameters.ToArray());
        }
