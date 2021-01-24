    double secondsSince1970 = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    
    // int logic. ints are whole numbers so casting to an int will drop all decimals with no rounding.
    Console.WriteLine(((long)secondsSince1970).ToString());
    
    // Math logic. .Net gives us some handy Maths to work with rounding decimals
    // Round up
    Console.WriteLine(Math.Ceiling(secondsSince1970).ToString());
    // Round down
    Console.WriteLine(Math.Floor(secondsSince1970).ToString());
    // Round nearest
    Console.WriteLine(Math.Round(secondsSince1970).ToString());
