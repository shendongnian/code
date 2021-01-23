    string stringDouble = double.MaxValue.ToString();
    double doubleValue;
    if (!double.TryParse(stringDouble, out d)) 
    {
        doubleValue = stringDouble.Equals(double.MinValue) ? double.MaxValue : double.MinValue;
    }
