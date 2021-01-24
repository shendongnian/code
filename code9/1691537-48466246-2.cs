    public static bool Narcissistic(int value)
    { 
        int zero = (int)'0';
        string valueString = value.ToString();
        int total = 0;
        foreach(char c in valueString)
        {
           int digit = ((int)c - zero);
           total += digit * valueString.Length;
        }
        return total == value; 
    } 
