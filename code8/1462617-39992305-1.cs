    int number = 95;
    while (number.ToString().Length > 1) // Do while we got a number that's 10 or more.
    {
        number = number.ToString() // Converts to string.
           .ToCharArray() // Splits it into an array of characters. (eg. one digit)
           .Select(x => (int)char.GetNumericValue(x)) // Converts that character into an int.
           .Sum(); // Calculate the sum.
    }
