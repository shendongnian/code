    int parsedMonth;
    if (int.TryParse(birthMonth, out parsedMonth))
    {
        if (parsedMonth < 13)
        {
            // do whatever you need with the value
        }
        else
        {
            // out of range
        }
    }
    else
    {
        // not a number
    }
