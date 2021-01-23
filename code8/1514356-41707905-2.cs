    int[] Integers = Enumerable.Range(-5, 5 * 1000 * 1000).ToArray();
    
    void ArrayToStringAlois()
    {
        char[] buffer = new char[Integers.Length * 11]; // an integer can have 10 digits plus sign = 11 digits. This buffer is big enough for all possible numbers
        int startIdx = 0;
        for (int i = 0; i < Integers.Length; i++)
        {
            startIdx += ToCharArray(Integers[i], buffer, startIdx);
        }
    
        string lret = new string(buffer, 0, startIdx);
    
        GC.KeepAlive(lret);
    }
    
    public static int ToCharArray(int value, char[] buffer, int bufferIndex)
    {
        if (value == 0)
        {
            buffer[bufferIndex] = '0';
            return 1;
        }
        int len = 1;
        int upperBound = 0;
        if (value < 0)
        {
            buffer[bufferIndex] = '-';
            len = 2;
            upperBound = 1;
        }
        value = Math.Abs(value);
    
        for (int rem = value / 10; rem > 0; rem /= 10)
        {
            len++;
        }
    
        for (int i = len - 1; i >= upperBound; i--)
        {
            buffer[bufferIndex + i] = (char)('0' + (value % 10));
            value /= 10;
        }
        return len;
    }
    void ArrayToStringSteakOverCooked()
    {
        var numbers = new StringBuilder();
        var length = Integers.Length;
        for (int i = 0; i < length; i++)
        {
            numbers.Append(i.ToString());
        }
    
        var lret = numbers.ToString();
        GC.KeepAlive(lret);
    }
    void ArrayToStringKeithNicolasAlternate2()
    {
        var lret = string.Concat(Integers);
        GC.KeepAlive(lret);
    }
