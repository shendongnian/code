    int number = 5;
    for (int i = 0; i < number; i++)
    {
    	var starsCount = 1 + Math.Abs(Math.Floor(number / 2.0) - i);
    	var spacesCount = 1 + Math.Floor(number / 2.0) - starsCount;
    	var output = "";
    
    	for (int j = 0; j < starsCount; j++)
    		output += "*";
    	for (int k = 0; k < spacesCount; k++)
    		output += "  ";
    	for (int m = 0; m < starsCount; m++)
    		output += "*";
    
    	Console.WriteLine(output);
    }
