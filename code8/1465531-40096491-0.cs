    void Main()
    {
        string input = "0000Z";
        int value = baseToInt(input, 36);
        value++;
        string output = intToBase(value, 36).PadLeft(5, '0');
        
        Console.WriteLine("Input: {0}", input);
        Console.WriteLine("Output: {0}", output);
    }
    
    public string intToBase(int input, int @base)
    {
        var digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
        if (@base < 2 || @base > 36)
        {
            throw new ArgumentOutOfRangeException("base", "Must specify a base between 2 and 36, inclusive");
        }
    
        if (input < @base && input >= 0)
        {
            return digits[input].ToString();
        }
        else
        {
            return intToBase(input / @base, @base) + digits[input % @base].ToString();
        }
    }
    
    public int baseToInt(string input, int @base)
    {
        var digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
        if (@base < 2 || @base > 36)
        {
            throw new ArgumentOutOfRangeException("base", "Must specify a base between 2 and 36, inclusive");
        }
    
        var digitsInBase = digits.Substring(0, @base);
    
        if (input.Any(c => !digitsInBase.Contains(c)))
        {
            throw new ArgumentOutOfRangeException("input", string.Format("Input is not a valid base {0} number", @base));
        }
    
        return (int)input.Select((c, i) => Math.Pow(@base, input.Length - (i + 1)) * digitsInBase.IndexOf(c)).Sum();
    
    }
    
