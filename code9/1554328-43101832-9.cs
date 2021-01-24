    string[] values_in_string = inputString.ToString().Split(',');
    double val = 0;
    List<double> values_in_double = values_in_string
        .Where(value => double.TryParse(value, NumberStyles.Any, 
            System.Globalization.CultureInfo.InvariantCulture, out val))
        .Select(v => val)
        .ToList();
