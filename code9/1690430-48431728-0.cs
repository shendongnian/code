    private void Init()
    { 
        var result = GetAscii("AF");
        int sum = 0;
    
        foreach (var itm in result)
        {
           // show each ascii value
           Console.WriteLine(itm.ToString());
            sum += (int)itm;
        }
        // sum all values
        Console.WriteLine(sum.ToString());
    }
    
    private byte[] GetAscii(string value)
    {
        byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
        return asciiBytes; 
    }
