    // this is from System.Text namespace
    StringBuilder sbResult = new StringBuilder();
    foreach (var input in inputs)
    { 
        if (!strSet.Contains(input))
            {
                sbResult.AppendFormat("{0} ", input);
            }
        }
    }
    string result = sbResult.ToString().Trim();
