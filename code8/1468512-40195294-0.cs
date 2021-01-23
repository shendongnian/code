    int x = strEquation.Count(c => Char.IsNumber(c)); // 6
    int y = strEquation.Count(c => Char.IsLetter(c)); // 3
    int z = strEquation.Count(c => Char.Equals('(')); // 4
    
    int total=x+y+z;
