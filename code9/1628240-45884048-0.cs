    string numbers = "12467930";
    char[] delimiters = { '-', '*' };
    StringBuilder result = new StringBuilder(numbers.Length * 2);
    for (int i = 0; i < numbers.Length - 1; ++i)
    {
        int value1 = (int)char.GetNumericValue(numbers[i]);
        int value2 = (int)char.GetNumericValue(numbers[i + 1]);
        int mod1 = value1 % 2;
        int mod2 = value2 % 2;
        if (value1 != 0 && mod1 == mod2)
            result.AppendFormat("{0}{1}", value1, delimiters[mod1]);
        else
            result.Append(value1);
    }
    result.Append(numbers.Last());
    return result.ToString();
