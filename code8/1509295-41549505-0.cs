    int number = 587;
    int maximum = Int32.MaxValue;
    var inputDigits = number.ToString().Select(c => Int32.Parse(new string(c, 1))).ToList();
    var limitDigits = maximum.ToString().Select(c => Int32.Parse(new string(c, 1))).ToList();
    var orderedDigits = inputDigits.OrderByDescending(c => c).ToList();
    var result = "";
    int position = 0;
    bool compareValues = limitDigits.Count <= inputDigits.Count;
    while (orderedDigits.Count > 0)
    {
        for (int i = 0; i < orderedDigits.Count; i++)
        {
            if (orderedDigits[i] > limitDigits[position])
            {
                if (compareValues)
                {
                    continue;
                }
            }
            else if (orderedDigits[i] < limitDigits[position])
            {
                compareValues = false;
            }
            result += (orderedDigits[i].ToString());
            orderedDigits.RemoveAt(i);
            break;
        }
        position++;
    }
    var intResult = Int32.Parse(result);
