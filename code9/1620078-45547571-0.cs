    string[] splitted = value.ToString(CultureInfo.InvariantCulture).Split('.');
    string newDecimal = splitted[0];
    if (splitted.Length > 1)
    {
        newDecimal += ".";
        newDecimal += splitted[1].Substring(0, Math.Min(splitted[1].Length, 5));
    }
    decimal result = Convert.ToDecimal(newDecimal, CultureInfo.InvariantCulture);
