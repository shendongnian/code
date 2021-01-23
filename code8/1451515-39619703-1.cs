    static void Main()
    {
        var test = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ".ToCharArray();
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Array.Sort(test);
        Console.WriteLine(new string(test)); // Wrong result using default char comparer.
          
        Array.Sort(test, new CharComparer(CultureInfo.GetCultureInfo("lt")));  // Right result using string comparer.
        Console.WriteLine(new string(test));
    }
