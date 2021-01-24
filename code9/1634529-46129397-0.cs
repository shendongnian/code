    using System.Globalization;
    ...
    // with any you did not have to care about decimal points and thousand sign
    // leading sign and so on..
    decimal Q1 = Decimal.Parse("5E-3", NumberStyles.Any); // Q1 = 0.005
    // or explicit:
    decimal Q2 = Decimal.Parse("-1E-1", NumberStyles.AllowExponent 
                                        | NumberStyles.AllowDecimalPoint 
                                        | NumberStyles.AllowLeadingSign);  // Q2 = -0,1
