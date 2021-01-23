    // Get quantities for populating quantity UI selector
    QuantityType[] quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().ToArray();
    
    // If Length is selected, get length units for populating from/to UI selectors
    LengthUnit[] lengthUnits = Length.Units;
    
    // Perform conversion by using .ToString() on selected units
    double centimeters = UnitConverter.ConvertByName(5, "Length", "Meter", "Centimeter");
    double centimeters2 = UnitConverter.ConvertByAbbreviation(5, "Length", "m", "cm");
