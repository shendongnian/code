    static double[] ParseTransformMatrix(string transform)
    {
        if (String.IsNullOrWhiteSpace(transform))
            return null;
        if (!(transform.StartsWith("matrix(") && transform.EndsWith(")")))
            return null;
        return transform
            .Substring(7, transform.Length - 8)
            .Split(',')
            .Select(s => Double.Parse(s, System.Globalization.CultureInfo.InvariantCulture))
            .ToArray();
    }
