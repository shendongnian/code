    // Mock values read from file
    var input = new StringBuilder();
    input.Append("0.20055,0.37951,0.39641,2.0472,32.351,0.38825,0.24976,1.3305‌​,");
    input.Append("1.1389,0.50494,0.24‌​976,0.6598,0.1666,0.‌​24976,497.42,0.73378‌​,");
    input.Append("2.6349,0.24976,0.14‌​942,43.37,1.2479,0.2‌​1402,0.11998,0.47706‌​,");
    input.Append("‌​0.50494,0.60411,1.4‌​582,1.7615,5.9443,0.‌​11788,593.27,0.50‌​591,");
    input.Append("0.12804,0.66295,0.14942,94.14,‌​3.8772,0.56393,0.214‌​02,1.741,");
    input.Append("1.5‌​225,49.394,0.1853,0.‌​11085,2.042,0.051402,0.12804,114‌​.42,");
    input.Append("71.05,1.0097,348690,0.12196,0.39‌​718,0.87804,0.37854,‌​0.25792,");
    input.Append("2.2437,2.248‌​,0.001924‌​,8.416,5.1372,82.658‌​,4.4158,7.4277");
            
    string[] values_in_string = inputString.ToString().Split(',');
    // Declare values_in_double as a List so we don't have to worry about sizing
    List<double> values_in_double = new List<double>();
    // We will get errors if numCols is larger than our string array, so to be safe,
    // set a variable that is the smallest of either numCols or our string array length
    var numIterations = Math.Min(numCols, values_in_string.Length);
    for (int x = 0; x < numIterations; x++)
    {
        double val;
        // If TryParse succeeds, 'val' will contain the double value, so add it to our List
        if (double.TryParse(values_in_string[x], NumberStyles.Any, 
            System.Globalization.CultureInfo.InvariantCulture, out val))
        {
            values_in_double.Add(val);
        }
    }
