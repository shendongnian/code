    string stringDouble = double.MaxValue.ToString();
    double doubleValue;
    if (!double.TryParse(stringDouble, out doubleValue)) 
    {
        doubleValue = stringDouble.Equals(double.MaxValue) ? double.MaxValue : double.MinValue;
    }
