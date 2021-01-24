    // configure the calibration/mapping.
    var calibrator = new RegexTextCalibrator();
    calibrator.AddParallelPattern(
                    new[] { "husband", "hus", "h" }, // defines one side of the pattern
                    new[] { "wife", "w" }, // defines the other side of the pattern
                    "H and W"); // defines the result
    
    // the inputs that will be mapped
    var inputs = new string[] {
        "Husband and Wife",
        "Wife and Husband",
        "Husband and Wife",
        "Wife and Husband",
        "hus & wife",
        "H & W"
    };
    
    // loops through the inputs and map them to the desired value
    foreach (var input in inputs)
        Console.WriteLine(calibrator.Resolve(input)); // prints "H and W"...
