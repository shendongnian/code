       static FileSizeConverter()
       {
            // decimal "contraction" units 
    
            knownUnits = new Dictionary<string, long>
            {
                { "", 1L },
                { "M", 1000L * 1000L }, // million
                { "B", 1000L * 1000L * 1000L } // billion (usa)
                // fill rest as needed
            };
    
            numberFormat = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
        }
