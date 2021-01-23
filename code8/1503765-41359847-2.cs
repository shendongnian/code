    string[] paramValues = parameterString.Split(',');
    var paramNames = Enumerable
      .Range(0, paramValues.Length)
      .Select(index => $"@prm{index}")
      .ToArray();
    string query = $"SELECT * from test WHERE testId IN ({string.Join(",", paramNames)})";
    ...
    for (int i = 0; i < paramNames.Length; ++i)
      command.Parameters.Add(new SqlParameter(paramNames[i], paramValues[i]));
