    void Main()
    {
        string template = @"AAAA00";
    
        var templateChars = template.ToCharArray();
        
        for (int i = 0; i < 100000; i++)
        {
            templateChars = IncrementCharArray(templateChars);
            Console.WriteLine(string.Join("",templateChars ));
        }
    }
    
    public static char Increment(char val)
    {
        if(val == '9') return 'A';
        if(val == 'Z') return '0';
        
        return ++val;
    }
    
    public static char[] IncrementCharArray(char[] val)
    {
        if (val.All(chr => chr == 'Z'))
        {
            var newArray = new char[val.Length + 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = '0';
            }
            
            return newArray;
        }
    
        int length = val.Length;
        
        while (length > -1)
        {
            char lastVal = val[--length];
    
            val[length] = Increment(lastVal);
            
            if ( val[length] != '0') break;
        }
        
        return val;
    }
