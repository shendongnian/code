    for (int i = 0; i < 5; i++)
    {
        var starsCount = Math.Abs(2 - i) + 1;
        var spacesCount = 3 - starsCount;
        var output = "";
    
        for (int j = 0; j < starsCount; j++)
            output += "*";
        for (int k = 0; k < spacesCount; k++)
            output += "  ";
        for (int m = 0; m < starsCount; m++)
            output += "*";
    
        Console.WriteLine(output);
    }
