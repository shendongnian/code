    DateTime output;
    if (DateTime.TryParseExact(input, frenchFormatString, frenchCulture, out output))
    {
        // Read it successfully
    }
    else if (DateTime.TryParseExact(input, englishFormatString, englishCulture, out output))
    {
        // Read it successfully 
    }
    else
    {
        // Unknown format, try something else?
    }
