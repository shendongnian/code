    static void Main(string[] args)
    {
        string test = @"BCROSS11,Documentname.doc,\STUDPRINT2\computername,15/05/2010,14:48,\1234566788,Insufficient balance,,,/Ts=4BEEA622,107502,10,,";
        // Split the string and it will return an array of strings
        string[] split_array = test.Split(',');
        // Test output to the console
        Console.WriteLine(String.Join("\n", split_array));
        Console.WriteLine("END");
        Console.ReadKey();
    }
