    // Display currency symbol. For country specific currency, set 
    // culture using globalization element in web.config. 
    // For Great Britain Pound symbol
    // <globalization culture="en-gb"/>
    [DataType(DataType.Currency)]
    public int? Salary { get; set; }
