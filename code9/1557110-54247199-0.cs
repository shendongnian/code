    var format = new NumberFormatInfo();
    format.NegativeSign = "-";
    format.NumberNegativePattern = 1;
    format.NumberDecimalSeparator = ".";
    double negativeNumber;
    Double.TryParse("-14.3", NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, format, out negativeNumber); // -14.3
    double positiveNumber;
    Double.TryParse("352.6", NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, format, out positiveNumber); // 352.6
