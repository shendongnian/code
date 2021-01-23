    int number = 587;
    int maximum = Int32.MaxValue;
    var inputDigits = number.ToString().Replace("-", String.Empty).Select(c => Int32.Parse(new string(c, 1))).ToList();
    var limitDigits = maximum.ToString().Select(c => Int32.Parse(new string(c, 1))).ToList();
    var orderedDigits = inputDigits.OrderByDescending(c => c).ToList();
    var result = "";
    int position = 0;
    // we only have to compare to the maximum if we have at least the same amount of digits in the input.
    bool compareValues = limitDigits.Count <= inputDigits.Count;
    // while we have not used all of the digits
    while (orderedDigits.Count > 0)
    {
        // loop over the remaining digits from high to low values
        for (int i = 0; i < orderedDigits.Count; i++)
        {
            // if it is above the digit in the maximum at the corresponding place we may only use it if input is shorter than maximum or if we have already used a lower value in a previous digit.
            if (orderedDigits[i] > limitDigits[position])
            {
                if (compareValues)
                {
                    continue;
                }
            }
            else if (orderedDigits[i] < limitDigits[position])
            {
                // remember that we have already used a lower value
                compareValues = false;
            }
            result += (orderedDigits[i].ToString());
            orderedDigits.RemoveAt(i);
            break;
        }
        position++;
    }
    var intResult = Int32.Parse(result);
