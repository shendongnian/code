    double coPrice = 0.0;
    double.TryParse(splitRow[1], out coPrice);
    rowResult.coPrice = coPrice;
    // The value will be 0.0 if the input is not convertible or
    // else it will be populated with the required value
